using BlogProjeKampı.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjeKampı.Controllers
{
	
	public class WriterController : Controller
	{
		private readonly IWriterServices _writerServices;
		private readonly ICityServices _cityServices;
		private readonly UserManager<AppUser> _userManager;
		public WriterController(IWriterServices writerServices, ICityServices cityServices, UserManager<AppUser> userManager)
		{
			_writerServices = writerServices;
			_cityServices = cityServices;
			_userManager = userManager;
		}



		[Authorize]
        public async Task<IActionResult> Index()
		{
           var value=await _userManager.FindByNameAsync(User.Identity.Name);
			var name1 = value.NameSurname;
			ViewBag.Name1 = name1;
            return View();
		}

		//public PartialViewResult PartialNavbar()
		//{
			
  //          return PartialView();
		//}
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
		[HttpGet]
		public async Task<IActionResult> WriterEditProfile()
		{
			//List<SelectListItem> list = (from x in _cityServices.TGetList()
			//							 select new SelectListItem
			//							 {
			//								 Text = x.CityName,
			//								 Value = x.CityID.ToString()
			//							 }).ToList();
			//ViewBag.city = list;
			//Context context = new Context();
			//UserManager userManager = new UserManager(new EFUserRepository());
			//var userName = User.Identity.Name;
			//var userMail= context.Users.Where(x=>x.UserName == userName).Select(x=>x.Email).FirstOrDefault();
			//var id= context.Users.Where(x=>x.Email==userMail).Select(x=>x.Id).FirstOrDefault();
			//var value = userManager.TGetById(id);
			var value= await _userManager.FindByNameAsync(User.Identity.Name);
			UserUpdateViewModel user= new UserUpdateViewModel();
			user.namesurname = value.NameSurname;
			user.mail = value.Email;
			user.username = value.UserName;
			user.image = value.ImageUrl;
			return View(user);
		}
		[HttpPost]
		public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel userUpdate)
		{
			var value= await _userManager.FindByNameAsync(User.Identity.Name);
			userUpdate.namesurname = value.NameSurname;
			userUpdate.mail = value.Email;
			userUpdate.image = value.ImageUrl;
			userUpdate.username = value.UserName;
			value.PasswordHash = _userManager.PasswordHasher.HashPassword(value, userUpdate.password);
			var result = await _userManager.UpdateAsync(value);
			return RedirectToAction("Index","Dashboard");
        }
		[HttpGet]
		public IActionResult AddWriter()
		{
			List<SelectListItem> list = (from x in _cityServices.TGetList()
										 select new SelectListItem
										 {
											 Text = x.CityName,
											 Value = x.CityID.ToString()
										 }).ToList();
			ViewBag.city = list;
			return View();
		}
		[HttpPost]
        public IActionResult AddWriter(AddProfileImage addProfile)
        {
			Writer writer = new Writer();
			if(addProfile.WriterImage!=null)
			{
				var extension = Path.GetExtension(addProfile.WriterImage.FileName);
				var newimagename = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
				var stream= new FileStream(location, FileMode.Create);
				addProfile.WriterImage.CopyTo(stream);
				writer.WriterImage = newimagename;
			}
			writer.WriterMail= addProfile.WriterMail;
			writer.WriterName= addProfile.WriterName;
			writer.WriterPassword= addProfile.WriterPassword;
			writer.ConfirmPassword= addProfile.ConfirmPassword;
			writer.WriterAbout= addProfile.WriterAbout;
			writer.CityID= addProfile.CityID;
			writer.WriterStatus = true;

			_writerServices.TAdd(writer);
			return RedirectToAction("Index", "Dashboard");
        }
    }
}
