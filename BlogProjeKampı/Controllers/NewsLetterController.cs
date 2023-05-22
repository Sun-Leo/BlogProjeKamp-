using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterServices _newsLetterServices;

        public NewsLetterController(INewsLetterServices newsLetterServices)
        {
            _newsLetterServices = newsLetterServices;
        }

        [HttpGet]
        public PartialViewResult PartialSubscribe()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialSubscribe(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            _newsLetterServices.TAdd(newsLetter);
            return RedirectToAction("Index","Blog");
        }

    }

}
