using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
