using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

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
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		//public PartialViewResult CommentListByBlog(int id)
		//{
		//	var value = _commentServices.TGetListAll(id);
		//	return PartialView(value);
		//}
	}
}
