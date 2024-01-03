using CarBook.Dtos.PricingDtos;
using CarBook.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           var value= await MethodInvoke<ResultCarCountDto>("GetCarCount" );
           var value2= await MethodInvoke<ResultLocationCountDto>("GetLocationCount");
           var value3 = await MethodInvoke<ResultBrandCountDto>("GetBrandCount" );
           var value4= await MethodInvoke<ResultCarCountByFuelElectricDto>("GetCarCountByFuelElectric");
            ViewBag.carCount = value.CarCount;
            ViewBag.locationCount = value2.LocationCount;
            ViewBag.brandCount = value3.BrandCount;
            ViewBag.carCountByFuelElectric = value4.CarCountByFuelElectric;

            return View();
        }

        private async Task<T> MethodInvoke<T>(string query)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Statistics/"+query);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<T>(jsonData);
                return values;
            }
            else return default(T);
        }
    }
}
