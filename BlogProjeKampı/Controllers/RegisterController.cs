using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
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
		[HttpPost]
		public IActionResult Index(Writer writer)
		{
			writer.WriterStatus = true;
			_writerServices.TAdd(writer);
			return RedirectToAction("Index", "Blog");
		}
	}
}
