using BlogProjeKampı.Models;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlogProjeKampı.Controllers
{
	
	public class WriterController : Controller
	{
		private readonly IWriterServices _writerServices;
		private readonly ICityServices _cityServices;

        public WriterController(IWriterServices writerServices, ICityServices cityServices)
        {
            _writerServices = writerServices;
			_cityServices = cityServices;	
        }

        public IActionResult Index()
		{
			return View();
		}

		public PartialViewResult PartialNavbar()
		{
			
			return PartialView();
		}
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			//List<SelectListItem> list = (from x in _cityServices.TGetList()
			//							 select new SelectListItem
			//							 {
			//								 Text = x.CityName,
			//								 Value = x.CityID.ToString()
			//							 }).ToList();
			//ViewBag.city = list;
			var value = _writerServices.TGetById(1);
			return View(value);
		}
		[HttpPost]
		public IActionResult WriterEditProfile(Writer writer)
		{

			WriterValidator validations = new WriterValidator();
			ValidationResult result = validations.Validate(writer);
			if(result.IsValid & writer.WriterPassword==writer.ConfirmPassword)
			{
				_writerServices.TUpdate(writer);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				if(!result.IsValid)
				{
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }

                else if (writer.WriterPassword != writer.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Şifreler Uyuşmadı");
                }
                
            }
			return View();
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
