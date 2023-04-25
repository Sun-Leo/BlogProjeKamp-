using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Controllers
{
	public class AboutController : Controller
	{
		private readonly IAboutServices _aboutServices;

		public AboutController(IAboutServices aboutServices)
		{
			_aboutServices = aboutServices;
		}

		public IActionResult Index()
		{
			var value = _aboutServices.TGetList();
			return View(value);
		}

	}
}
