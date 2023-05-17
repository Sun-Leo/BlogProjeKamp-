using BlogProjeKampıAPI.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjeKampıAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c= new Context();
            var category = c.Categories.ToList();
            return Ok(category);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            using var c = new Context();
            c.Add(category);
            c.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult CategoryGetByID(int id)
        {
            using var c= new Context();
           var value=c.Categories.Find(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            using var c= new Context();
            var value1= c.Categories.Find(id);
            if(value1==null) 
            { 
                return NotFound();
            }
            else
            {
                c.Remove(value1);
                c .SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            using var c= new Context();
            var value2 = c.Find<Category>(category.CategoryID);
            if (value2 == null)
            {
                return NotFound();
            }
            else
            {
               value2.CategoryName = category.CategoryName;
                value2.CategoryStatus = category.CategoryStatus;
                value2.CategoryColor = category.CategoryColor;
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
