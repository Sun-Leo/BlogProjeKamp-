using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjeKampı.ViewComponents
{
    public class NavbarWriter: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(x => x.WriterID).FirstOrDefault();
            var name = context.Writers.Where(x => x.WriterID == writerId).Select(x => x.WriterName).FirstOrDefault();
            ViewBag.name = name;
            return View();
        }
    }
}
