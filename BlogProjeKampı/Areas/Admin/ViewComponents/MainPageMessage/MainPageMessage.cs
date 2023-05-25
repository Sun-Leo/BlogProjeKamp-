using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Areas.Admin.ViewComponents.MainPageMessage
{
    public class MainPageMessage: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
