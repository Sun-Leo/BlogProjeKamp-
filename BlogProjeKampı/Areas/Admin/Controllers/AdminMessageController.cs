﻿using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminMessageController : Controller
    {
        private readonly IMessage2Services _message2Service;

        public AdminMessageController(IMessage2Services message2Service)
        {
            _message2Service = message2Service;
        }
        Context context= new Context();

        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(x => x.WriterID).FirstOrDefault();
            var value = _message2Service.TGetListMessageWithWriter(writerId);
            return View(value);
        }
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(x => x.WriterID).FirstOrDefault();
            var value = _message2Service.GetSendBoxListByWriter(writerId);
            return View(value);
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(Message2 message2)
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(x => x.WriterID).FirstOrDefault();
            message2.SenderID = writerId;
            message2.ReceiverID = 2;
            message2.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2.MessageStatus = true;
            _message2Service.TAdd(message2);
            return RedirectToAction("SendBox");
        }
    }
}
