using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessage2Services _message2Services;

        public MessageController(IMessage2Services message2Services)
        {
            _message2Services = message2Services;
        }

        public IActionResult InBox()
        {
            int id = 1;
            var value= _message2Services.TGetListMessageWithWriter(id);
            return View(value);
        }
        public IActionResult MessageDetail(int id)
        {
            var value= _message2Services.TGetById(id);
            return View(value);
        }
    }
}
