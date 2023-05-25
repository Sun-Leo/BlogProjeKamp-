using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    public class AdminBlogController : Controller
    {
        private readonly IBlogServices _blogServices;

        public AdminBlogController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            var value = _blogServices.TGetListWithCategory();
            return View(value);
        }
    }
}
