using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogServices _blogServices;

		public BlogController(IBlogServices blogServices)
		{
			_blogServices = blogServices;
		}

		public IActionResult Index()
        {
            var value = _blogServices.TGetListWithCategory();
            return View(value);
        }
        public IActionResult BlogDetails(int id)
        {
            ViewBag.i = id;
            var value = _blogServices.TGetListAll(id);
            return View(value);
        }
    }
}
