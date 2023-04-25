using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Controllers
{
	public class LoginController : Controller
	{
		private readonly IWriterServices _writerServices;

        public LoginController(IWriterServices writerServices)
        {
            _writerServices = writerServices;
        }
		[HttpGet]
        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
        public IActionResult Index(Writer writer)
        {
            
            return View();
        }
    }
}
