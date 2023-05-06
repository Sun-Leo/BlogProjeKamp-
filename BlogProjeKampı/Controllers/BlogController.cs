using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogProjeKampı.Controllers
{
    
    public class BlogController : Controller
    {       
        private readonly IBlogServices _blogServices;
        private readonly ICategoryServices _categoryServices;

		public BlogController(IBlogServices blogServices, ICategoryServices categoryServices)
		{
			_blogServices = blogServices;
            _categoryServices = categoryServices;
		}

		public IActionResult Index()
        {
            var value = _blogServices.TGetListWithCategory();
            return View(value);
        }
        public IActionResult BlogDetails(int id)
        {
            ViewBag.i = id;
            var value = _blogServices.TGetListAll(id);
            return View(value);
        }
        public IActionResult BlogListByWriter()
        {
           var value= _blogServices.TGetListWithCategoryByWriter(1);
            return View(value);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> List= (from x in _categoryServices.TGetList()
                                        select new SelectListItem
                                        {
                                            Text=x.CategoryName,
                                            Value=x.CategoryID.ToString()
                                        }).ToList();
            ViewBag.cv = List;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult validationResult = bv.Validate(blog);
            if(validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = 1;
                _blogServices.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
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

        [HttpGet]
        public IActionResult BlogUpdate(int id) 
        { 
            List<SelectListItem> list=(from x in _categoryServices.TGetList()
                                       select new SelectListItem
                                       {
                                           Text = x.CategoryName,
                                           Value=x.CategoryID.ToString()
                                       }).ToList();
            ViewBag.ct=list;
            var blogvalue= _blogServices.TGetById(id);
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult BlogUpdate(Blog blog)
        {
            blog.WriterID = 1;
            blog.BlogStatus=true;
            _blogServices.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
