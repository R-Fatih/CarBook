using CarBook.Dtos.CommentChildrenDtos;
using CarBook.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentChildrenListByCommentComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentChildrenListByCommentComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7224/api/CommentChildrens/GetCommentChildrenByCommentQuery/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentChildrenDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
