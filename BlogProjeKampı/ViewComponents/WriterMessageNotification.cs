using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.ViewComponents
{
    public class WriterMessageNotification:ViewComponent
    {
        private readonly IMessageServices _messageServices;

        public WriterMessageNotification(IMessageServices messageServices)
        {
            _messageServices = messageServices;
        }

        public IViewComponentResult Invoke()
        {
            string p;
            p = "gizem@gmail.com";
            var value = _messageServices.TGetInboxByWriter(p);
            return View(value);
        }
    }
}
