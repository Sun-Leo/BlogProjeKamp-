using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.ViewComponents
{
	public class CommentListByBlog: ViewComponent
	{
		private readonly ICommentServices _commentServices;

		public CommentListByBlog(ICommentServices commentServices)
		{
			_commentServices = commentServices;
		}

		public IViewComponentResult Invoke()
		{
			var value = _commentServices.TGetListAll(1);
			return View(value);
		}
	}
}
