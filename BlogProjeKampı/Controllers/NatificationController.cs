using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Controllers
{
    public class NatificationController : Controller
    {
        private readonly INatificationServices _natificationServices;

        public NatificationController(INatificationServices natificationServices)
        {
            _natificationServices = natificationServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult AllNotification()
        {
            var value= _natificationServices.TGetList();
            return View(value);
        }
    }
}
