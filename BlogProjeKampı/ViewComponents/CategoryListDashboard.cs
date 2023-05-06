using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.ViewComponents
{
    public class CategoryListDashboard: ViewComponent
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryListDashboard(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IViewComponentResult Invoke()
        {
            var value = _categoryServices.TGetList();
            return View(value);
        }
    }
}
