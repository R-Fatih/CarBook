
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FeaturesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> FeatureList()
		{
			return Ok(await _mediator.Send(new GetFeatureQuery()));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetFeature(int id)
		{
			return Ok(await _mediator.Send(new GetFeatureByIdQuery(id)));
		}
		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
		{
			await _mediator.Send(command);
			return Ok("Özellik bilgisi eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveFeature(int id)
		{
			await _mediator.Send(new RemoveFeatureCommand(id));
			return Ok("Özellik bilgisi silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
		{
			await _mediator.Send(command);
			return Ok("Özellik bilgisi güncellendi.");
		}
	}
}
