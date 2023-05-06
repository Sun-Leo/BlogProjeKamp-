using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.ViewComponents
{
    public class BlogListDashboard: ViewComponent
    {
        private readonly IBlogServices _blogServices;

        public BlogListDashboard(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }

        public IViewComponentResult Invoke()
        {
            var value = _blogServices.TGetListWithCategory();
            return View(value);
        }
    }
}
