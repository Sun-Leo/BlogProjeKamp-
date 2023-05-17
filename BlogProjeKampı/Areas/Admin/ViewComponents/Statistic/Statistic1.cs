using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace BlogProjeKampı.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1: ViewComponent
    {
        private readonly IBlogServices _blogServices;
        private readonly IContactServices _contactServices;
        private readonly ICommentServices _commentServices;

        public Statistic1(IBlogServices blogServices, IContactServices contactServices, ICommentServices commentServices)
        {
            _blogServices = blogServices;
            _contactServices = contactServices;
            _commentServices = commentServices;
        }

        public IViewComponentResult Invoke()
        {
            var sum = _blogServices.TGetList().Count;
            ViewBag.v1=sum;
            ViewBag.v2= _contactServices.TGetList().Count;
            ViewBag.v3= _commentServices.TGetList().Count;

            string api = "e880bafd8c10b0452c833ef05db6f6d9";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Istanbul&mode=xml&appid=" + api;
            XDocument document= XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
