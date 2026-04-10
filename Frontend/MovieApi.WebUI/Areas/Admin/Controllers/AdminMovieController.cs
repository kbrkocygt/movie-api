using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApi.Dto.Dtos.AdminMovieDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminMovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ActionResult> MovieList()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5089/api/Movies/GetMovieWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultMovieDto>>(jsonData);
                return View(values);
            }
            return View();

        }
        [HttpGet]
        public IActionResult CreateMovie()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = client.GetAsync("http://localhost:5089/api/Categories").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = responseMessage.Content.ReadAsStringAsync().Result;
                var values = JsonConvert.DeserializeObject<List<AdminResultCategoryDto>>(jsonData);
                ViewBag.Categories = new SelectList(values, "CategoryId", "CategoryName");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(AdminCreateMovieDto adminCreateMovieDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(adminCreateMovieDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5089/api/Movies", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("MovieList", "AdminMovie", new { area = "Admin" });
            }
            return View();
        }



    }
}
