using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BlogProjeKampı.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IWriterServices _writerServices;
		private readonly ICityServices _cityServices;

		public RegisterController(IWriterServices writerServices, ICityServices cityServices)
		{
			_writerServices = writerServices;
			_cityServices = cityServices;
		}
		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			List<SelectListItem> list=(from x in _cityServices.TGetList()
									   select new SelectListItem
									   {
										   Text=x.CityName,
										   Value=x.CityID.ToString()
									   }).ToList();
			ViewBag.list1 = list;
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public IActionResult Index(Writer writer)
		{
			WriterValidator wv = new WriterValidator();
			ValidationResult results = wv.Validate(writer);
			if (results.IsValid & writer.WriterPassword==writer.ConfirmPassword)
			{
				writer.WriterStatus = true;
				_writerServices.TAdd(writer);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				if(!results.IsValid & writer.WriterPassword != writer.ConfirmPassword)
				{
				
				foreach(var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);

				}
					ModelState.AddModelError("", "Şifreler uyuşmuyor.");

                }else if (!results.IsValid) 
				{ 
					foreach(var item in results.Errors)
					{
						ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
					}
				}else if(writer.WriterPassword != writer.ConfirmPassword)
				{
					ModelState.AddModelError("", "Şifreler uyuşmuyor");
				}
            }

			return View();

				
						
		}
	}
}
