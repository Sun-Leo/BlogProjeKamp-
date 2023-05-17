using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    public class RegisterAdminController : Controller
    {
        private readonly IAdminServices _adminServices;

        public RegisterAdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
