using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IBlogServices _blogServices;
        private readonly ICategoryServices _categoryServices;

        public DashboardController(IBlogServices blogServices, ICategoryServices categoryServices)
        {
            _blogServices = blogServices;
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = _blogServices.TGetCount();
            ViewBag.v2 = _blogServices.TGetWriterBlogCount(1);
            ViewBag.v3 = _categoryServices.TGetCount();
            return View();
        }

        //public PartialViewResult PartialFoto()
        //{
        //    return PartialView(); 
        //}
    }
}
