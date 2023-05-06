using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.ViewComponents
{
    public class NatificationList: ViewComponent
    {
        private readonly INatificationServices _natificationServices;

        public NatificationList(INatificationServices natificationServices)
        {
            _natificationServices = natificationServices;
        }

        public IViewComponentResult Invoke()
        {
            var value = _natificationServices.TGetList();
            return View(value);
        }
    }
}
