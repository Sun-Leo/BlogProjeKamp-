using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.ViewComponents
{
    public class BlogLast3Post: ViewComponent
    {
        private readonly IBlogServices _blogServices;

        public BlogLast3Post(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }

        public IViewComponentResult Invoke()
        {
            var value= _blogServices.TGetLast3Blog();
            return View(value);
        }
    }
}
