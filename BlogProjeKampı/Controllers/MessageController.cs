using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BlogProjeKampı.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessage2Services _message2Services;

        public MessageController(IMessage2Services message2Services)
        {
            _message2Services = message2Services;
        }
        Context context = new Context();

        public IActionResult InBox(int id)
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(x => x.WriterID).FirstOrDefault();
            var value= _message2Services.TGetListMessageWithWriter(writerId);
            return View(value);
        }
        public IActionResult MessageDetail()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(x => x.WriterID).FirstOrDefault();
            var value= _message2Services.TGetById(writerId);
            return View(value);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 message2)
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(x => x.WriterID).FirstOrDefault();
            

            message2.SenderID = writerId;
            message2.ReceiverID = 2;
            message2.MessageStatus = true;
            message2.MessageDate= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _message2Services.TAdd(message2);
            return RedirectToAction("InBox");
        }
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(x => x.WriterID).FirstOrDefault();
            var value= _message2Services.GetSendBoxListByWriter(writerId);
            return View(value);
        }
    }
}
