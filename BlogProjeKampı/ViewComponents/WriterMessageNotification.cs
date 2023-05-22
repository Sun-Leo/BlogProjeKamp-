using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjeKampı.ViewComponents
{
    public class WriterMessageNotification:ViewComponent
    {
        private readonly IMessage2Services _message2Services;

        public WriterMessageNotification(IMessage2Services message2Services)
        {
            _message2Services = message2Services;
        }
        Context context = new Context();

        public IViewComponentResult Invoke()
        {

            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(x => x.WriterID).FirstOrDefault();
            var value = _message2Services.TGetListMessageWithWriter(writerId);
            return View(value);
        }
    }
}
