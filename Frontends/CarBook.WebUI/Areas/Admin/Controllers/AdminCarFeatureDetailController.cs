using CarBook.Dtos.BlogDtos;
using CarBook.Dtos.CarFeatureDtos;
using CarBook.Dtos.CategoryDtos;
using CarBook.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/CarFeatures?carId=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Index/{id}")]

        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDtos)
        {
            foreach (var item in resultCarFeatureByCarIdDtos)
            {
                if (item.Available)
                {

                    var client = _httpClientFactory.CreateClient();
                   await client.GetAsync("https://localhost:7224/api/CarFeatures/UpdateCarFeatureAvailableChangeToTrue/" + item.CarFeatureId);
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7224/api/CarFeatures/UpdateCarFeatureAvailableChangeToFalse/" + item.CarFeatureId);
                }
            }
            return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
        }
        [Route("CreateFeatureByCarId")]
        public async Task<IActionResult> CreateFeatureByCarId(int carId)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
