using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentServices _commentServices;

        public CommentController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }

        public IActionResult Index()
        {
            var value = _commentServices.TGetCommentWithBlog();
            return View(value);
        }
    }
}
