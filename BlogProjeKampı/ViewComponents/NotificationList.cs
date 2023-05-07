using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.ViewComponents
{
    public class NotificationList:ViewComponent
    {
        private readonly INatificationServices _natificationServices;

        public NotificationList(INatificationServices natificationServices)
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
