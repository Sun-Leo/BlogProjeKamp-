using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        Context c = new Context();
        public IActionResult Index(int id)
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(x => x.WriterID).FirstOrDefault();
            ViewBag.v1 = _blogServices.TGetCount();
            ViewBag.v2 = c.Writers.Where(x=>x.WriterID == writerId).Select(x=>x.Blogs.Count).FirstOrDefault();
            ViewBag.v3 = _categoryServices.TGetCount();
            return View();
        }

        //public PartialViewResult PartialFoto()
        //{
        //    return PartialView(); 
        //}
    }
}
