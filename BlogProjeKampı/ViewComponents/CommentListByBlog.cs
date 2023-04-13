using BusinessLayer.Abstract;
using EntityLayer.Concrete;
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

		public IViewComponentResult Invoke(int id)
		{

			var value = _commentServices.TGetListAll(id);
			return View(value);
		}
	}
}
