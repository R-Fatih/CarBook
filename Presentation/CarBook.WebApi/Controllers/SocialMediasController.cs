
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediasController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SocialMediasController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> SocialMediaList()
		{
			return Ok(await _mediator.Send(new GetSocialMediaQuery()));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetSocialMedia(int id)
		{
			return Ok(await _mediator.Send(new GetSocialMediaByIdQuery(id)));
		}
		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sosyal medya bilgisi eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveSocialMedia(int id)
		{
			await _mediator.Send(new RemoveSocialMediaCommand(id));
			return Ok("Sosyal medya bilgisi silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sosyal medya bilgisi güncellendi.");
		}
	}
}
