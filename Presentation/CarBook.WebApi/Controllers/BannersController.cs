using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannersController : ControllerBase
	{
		private readonly CreateBannerCommandHandler _createCommandHandler;
		private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
		private readonly GetBannerQueryHandler _getBannerQueryHandler;
		private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
		private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

		public BannersController(CreateBannerCommandHandler createCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
		{
			_createCommandHandler = createCommandHandler;
			_getBannerByIdQueryHandler = getBannerByIdQueryHandler;
			_getBannerQueryHandler = getBannerQueryHandler;
			_updateBannerCommandHandler = updateBannerCommandHandler;
			_removeBannerCommandHandler = removeBannerCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> BannerList()
		{
			return Ok(await _getBannerQueryHandler.Handle());
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBanner(int id)
		{
			var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
			return Ok(value);

		}
		[HttpPost]
		public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
		{
			await _createCommandHandler.Handle(command);
			return Ok("Banner bilgisi eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveBanner(int id)
		{
			await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
			return Ok("Banner bilgisi silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
		{
			await _updateBannerCommandHandler.Handle(command);
			return Ok("Banner bilgisi güncellendi.");
		}
	}
}
