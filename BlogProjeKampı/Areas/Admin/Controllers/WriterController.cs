using BlogProjeKampıAPI.DAL;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
        [HttpGet]
      public IActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWriter(Writer writer)
        {
            writer.WriterStatus = true;
            var httpclient= new HttpClient();
            var jsonWriter= JsonConvert.SerializeObject(writer);
            StringContent content = new StringContent(jsonWriter, Encoding.UTF8,"application/json");
            var responseMessage = await httpclient.PostAsync("https://localhost:44354/api/Writer", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(writer);
        }

        [HttpGet]
        public async  Task<IActionResult> EditWriter(int id)
        {
            var httpClient=new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44354/api/Writer/"+ id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonWriter= await responseMessage.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<Writer>(jsonWriter);
                return View(value);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditWriter(Writer writer)
        {
            var httpClient= new HttpClient();
            var jsonWriter = JsonConvert.SerializeObject(writer);
            var content= new StringContent(jsonWriter, Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44354/api/Writer", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(writer);
        }

        public async Task<IActionResult> DeleteWriter(int id)
        {
            var httpClient=new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44354/api/Writer/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    

    
}
