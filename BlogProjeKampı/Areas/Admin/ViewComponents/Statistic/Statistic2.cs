using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogProjeKampı.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2: ViewComponent
    {
        private readonly IWriterServices _writerServices;
        Context context = new Context();

        public Statistic2(IWriterServices writerServices)
        {
            _writerServices = writerServices;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.writer = context.Writers.OrderByDescending(x => x.WriterID).Select(x => x.WriterName).FirstOrDefault();
            return View();
        }
    }
}
