using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.ViewComponents
{
	public class WriterLastBlog: ViewComponent
	{
		private readonly IBlogServices _blogServices;

		public WriterLastBlog(IBlogServices blogServices)
		{
			_blogServices = blogServices;
		}
		public IViewComponentResult Invoke()
		{
			var value= _blogServices.TGetBlogListByWriter(1);
			return View(value);

		}
	}
}
