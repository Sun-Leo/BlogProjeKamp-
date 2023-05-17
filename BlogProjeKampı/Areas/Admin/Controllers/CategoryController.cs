using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System;
using X.PagedList;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        Context context = new Context();

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            var value = _categoryServices.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator cv = new CategoryValidator();
            FluentValidation.Results.ValidationResult validationResult = cv.Validate(category);
            if (validationResult.IsValid)
            {
                category.CategoryStatus = true;
                _categoryServices.TAdd(category);
                return RedirectToAction("Index", "Category");

            }
            else
            {
                foreach(var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

            
        }
        public IActionResult DeleteCategory(int id)
        {
            var value=_categoryServices.TGetById(id);
            _categoryServices.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
