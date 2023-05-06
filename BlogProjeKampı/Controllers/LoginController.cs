using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogProjeKampı.Controllers
{
	public class LoginController : Controller
	{
		private readonly IWriterServices _writerServices;

        public LoginController(IWriterServices writerServices)
        {
            _writerServices = writerServices;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
		{
			return View();
		}
        [HttpPost]
		[AllowAnonymous]
		public async Task< IActionResult> Index(Writer writer)
        {
			Context context = new Context();
			var datavalue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
			if(datavalue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, writer.WriterMail)
				};
				var useridentity=new ClaimsIdentity(claims,"a");
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(claimsPrincipal);
				return RedirectToAction("Index","Dashboard");
			}
			else
			{
				return View();
			}

		}

	}
}
//Context context = new Context();
//var datavalue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
//if (datavalue != null)
//{
//	HttpContext.Session.SetString("username", writer.WriterMail);
//	return RedirectToAction("Index", "Writer");
//}
//else
//{
//	return View();
//}
