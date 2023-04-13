using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.ViewComponents
{
	public class CategoryListBlogDetails: ViewComponent
	{
		private readonly ICategoryServices _categoryServices;

		public CategoryListBlogDetails(ICategoryServices categoryServices)
		{
			_categoryServices = categoryServices;
		}

		public IViewComponentResult Invoke()
		{
			var category = _categoryServices.TGetList();
			return View(category);
		}
	}
}
