using CarBook.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7224/api/Blogs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultGetBlogById>(jsonData);


                var responseMessage2 = await client.GetAsync($"https://localhost:7224/api/Comments/GetCommentCountByBlog?id=" + id);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var values2 = JsonConvert.DeserializeObject<int>(jsonData2);
                    ViewBag.count = values2;
                }
                return View(values);
            }

           

            return View();
        }
    }
}
