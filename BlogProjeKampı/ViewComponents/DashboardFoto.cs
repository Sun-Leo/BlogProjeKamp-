using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.ViewComponents
{
    public class DashboardFoto: ViewComponent
    {
        private readonly IBlogServices _blogServices;

        public DashboardFoto(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }

        public IViewComponentResult Invoke()
        {
            var value= _blogServices.TGetList();
            return View(value);
        }
    }
}
