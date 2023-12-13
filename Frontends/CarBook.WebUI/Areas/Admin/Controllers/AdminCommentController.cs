using CarBook.Dtos.CarDtos;
using CarBook.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/AdminComment")]

    public class AdminCommentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminCommentController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[Route("Index/{id}")]
		public async Task<IActionResult> Index(int id)
		{
			ViewBag.v = id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7224/api/Comments/GetCommentsByBlogId?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		
		[Route("RemoveComment/{id}")]

		public async Task<IActionResult> RemoveComment(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/Comments?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}

			return View();

		}
		//CommentListByCommentId

	}
}
