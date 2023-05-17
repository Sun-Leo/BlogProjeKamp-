using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.ViewComponents
{
    public class WriterMessageNotification:ViewComponent
    {
        private readonly IMessage2Services _message2Services;

        public WriterMessageNotification(IMessage2Services message2Services)
        {
            _message2Services = message2Services;
        }

        public IViewComponentResult Invoke()
        {
            int id = 1;
            var value = _message2Services.TGetListMessageWithWriter(id);
            return View(value);
        }
    }
}
