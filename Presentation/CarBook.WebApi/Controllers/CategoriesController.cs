﻿using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly CreateCategoryCommandHandler _createCommandHandler;
		private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
		private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
		private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
		private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

		public CategoriesController(CreateCategoryCommandHandler createCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
		{
			_createCommandHandler = createCommandHandler;
			_getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
			_getCategoryQueryHandler = getCategoryQueryHandler;
			_updateCategoryCommandHandler = updateCategoryCommandHandler;
			_removeCategoryCommandHandler = removeCategoryCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{
			return Ok(await _getCategoryQueryHandler.Handle());
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategory(int id)
		{
			var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
			return Ok(value);

		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
		{
			await _createCommandHandler.Handle(command);
			return Ok("Kategori bilgisi eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveCategory(int id)
		{
			await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
			return Ok("Kategori bilgisi silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
		{
			await _updateCategoryCommandHandler.Handle(command);
			return Ok("Kategori bilgisi güncellendi.");
		}
	}
}
