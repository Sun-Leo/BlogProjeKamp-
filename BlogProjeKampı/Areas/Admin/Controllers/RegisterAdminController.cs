using BlogProjeKampı.Areas.Admin.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class RegisterAdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterAdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterAdminViewModel registerAdminView)
        {
            if(ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Email = registerAdminView.Mail,
                    NameSurname = registerAdminView.NameSurmane,
                    UserName = registerAdminView.UserName
                    
                };

                var result= await _userManager.CreateAsync(appUser, registerAdminView.Password);
                if( result.Succeeded)
                {
                    return RedirectToAction("Index", "LoginAdmin");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View(registerAdminView); 
        }
    }
}
