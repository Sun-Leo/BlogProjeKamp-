using BlogProjeKampıAPI.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjeKampıAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        [HttpGet]
        public IActionResult WriterList()
        {
            using var c= new Context();
            var writer=c.Writers.ToList();
            return Ok(writer);
        }
        [HttpPost]
        public IActionResult AddWriter(Writer writer)
        {
            using var c = new Context();
            c.Add(writer);
            c.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult WriterGetByID(int id)
        {
            using var c = new Context();
            var value = c.Writers.Find(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWriter(int id)
        {
            using var c = new Context();
            var value1 = c.Writers.Find(id);
            if(value1 == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value1);
                c.SaveChanges() ;
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult UpdateWriter(Writer writer)
        {
            using var c = new Context();
            var value2 = c.Find<Writer>(writer.WriterID);
            if (value2 == null)
            {
                return NotFound();
            }
            else
            {
                value2.WriterName = writer.WriterName;
                value2.WriterAbout = writer.WriterAbout;
                value2.WriterStatus = writer.WriterStatus;
                value2.WriterMail = writer.WriterMail;
                value2.WriterImage = writer.WriterImage;
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
