using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogProjeKampı.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		private readonly IContactServices _contactServices;

		public ContactController(IContactServices contactServices)
		{
			_contactServices = contactServices;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contact.ContactDate=DateTime.Parse(DateTime.Now.ToShortDateString());
			contact.ContactStatus = true;
			_contactServices.TAdd(contact);
			
			return RedirectToAction("Index","Blog");
		}
	}
}
