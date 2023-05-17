using BusinessLayer.Abstract;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogExcelController : Controller
    {
        private readonly IBlogServices _blogServices;

        public BlogExcelController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using(var workbook= new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1,1).Value = "Blog ID";
                worksheet.Cell(1,2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach(var item in _blogServices.BlogTitleListForExcel())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BlogID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogTitle;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }

            }
            return View();
        }
        public IActionResult BlogListTitleExcel()
        {
            return View();
        }
    }
}
