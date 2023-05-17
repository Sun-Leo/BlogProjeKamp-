using BlogProjeKampıAPI.DAL;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient= new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44354/api/Writer");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values= JsonConvert.DeserializeObject<List<Writer>>(jsonString);
            return View(values);
        }
    }
    
}
