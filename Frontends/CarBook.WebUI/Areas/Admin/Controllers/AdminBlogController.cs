﻿using CarBook.Dtos.CarDtos;
using CarBook.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/AdminBlog")]

    public class AdminBlogController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminBlogController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[Route("Index")]
		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7224/api/Blogs/GetAllBlogsWithAuthor");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		
		[Route("RemoveBlog/{id}")]

		public async Task<IActionResult> RemoveBlog(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/Blogs?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}

			return View();

		}
		//BlogListByBlogId

	}
}
