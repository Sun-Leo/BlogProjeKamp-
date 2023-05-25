using BlogProjeKampıAPI.DAL;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IBlogServices _blogServices;
        private readonly ICommentServices _commentServices;
        private readonly ICategoryServices _categoryServices;


        public MainPageController(UserManager<AppUser> userManager, ICommentServices commentServices, IBlogServices blogServices, ICategoryServices categoryServices)
        {
            _userManager = userManager;
            _commentServices = commentServices;
            _blogServices = blogServices;
            _categoryServices = categoryServices;
        }

        public async Task<IActionResult> Index()
        {
			var value= await _userManager.FindByNameAsync(User.Identity.Name);
            var blog = _blogServices.TGetList().Count();
            var comment=_commentServices.TGetList().Count();
            var category = _categoryServices.TGetList().Count();
            ViewBag.blg = blog;
            ViewBag.cmt=comment;
            ViewBag.ctgry=category;
            var name = value.NameSurname;
            ViewBag.Name = name;
            return View();
        }
    }
}
