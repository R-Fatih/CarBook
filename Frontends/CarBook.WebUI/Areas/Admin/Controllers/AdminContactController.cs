﻿using CarBook.Dtos.CarDtos;
using CarBook.Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/AdminContact")]

    public class AdminContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7224/api/Contacts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		
		[Route("RemoveContact/{id}")]

		public async Task<IActionResult> RemoveContact(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/Contacts?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}

			return View();

		}
		//ContactListByContactId

	}
}