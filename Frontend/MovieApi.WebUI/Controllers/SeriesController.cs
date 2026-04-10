using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.SeriesDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
    public class SeriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SeriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ActionResult> SeriesList()
        {
            ViewBag.v1 = "Diziler Listesi";
            ViewBag.v2 = "Anasayfa";
            ViewBag.v3 = "Diziler";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5089/api/Movies");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSeriesDto>>(jsonData);
                return View(values);
            }
            return View();

        }

        public async Task<ActionResult> MovieDetail(int id)
        {
            // ViewBag.v1 = "Film Detayı";
            // ViewBag.v2 = "Anasayfa";
            // ViewBag.v3 = "Film Detayı";

            // var client = _httpClientFactory.CreateClient();
            // var responseMessage = await client.GetAsync($"http://localhost:5089/api/Movies/{id}");
            // if (responseMessage.IsSuccessStatusCode)
            // {
            //     var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //     var values = JsonConvert.DeserializeObject<ResultMovieDto>(jsonData);
            //     return View(values);
            // }
            id = 0;
            return View();

        }

    }
}
