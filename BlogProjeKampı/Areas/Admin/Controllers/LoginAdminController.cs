using BlogProjeKampı.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class LoginAdminController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginAdminController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginAdminViewModel adminViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(adminViewModel.UserName, adminViewModel.Password,false,true);
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index","MainPage");
            }
            else
            {
                return View();
            }
            return View();
        }
        
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","LoginAdmin");
        }
    }
}
