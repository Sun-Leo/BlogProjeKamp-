using BlogProjeKampıAPI.DAL;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainPageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

		public MainPageController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
        {
			var value= await _userManager.FindByNameAsync(User.Identity.Name);
            var name = value.NameSurname;
            ViewBag.Name = name;
            return View();
        }
    }
}
