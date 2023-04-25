using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogProjeKampı.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentServices _commentServices;

		public CommentController(ICommentServices commentServices)
		{
			_commentServices = commentServices;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		[HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
			comment.CommentDate=DateTime.Parse(DateTime.Now.ToString());
			comment.CommentStatus = true;
			_commentServices.TAdd(comment);
            return PartialView("Index","Blog");
        }
        //public PartialViewResult CommentListByBlog(int id)
        //{
        //	var value = _commentServices.TGetListAll(id);
        //	return PartialView(value);
        //}
    }
}
