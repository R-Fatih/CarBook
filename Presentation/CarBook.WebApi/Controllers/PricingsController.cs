
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Handlers.PricingHandlers;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PricingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PricingsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> PricingList()
		{
			return Ok(await _mediator.Send(new GetPricingQuery()));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetPricing(int id)
		{
			return Ok(await _mediator.Send(new GetPricingByIdQuery(id)));
		}
		[HttpPost]
		public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Ödeme bilgisi eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemovePricing(int id)
		{
			await _mediator.Send(new RemovePricingCommand(id));
			return Ok("Ödeme bilgisi silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Ödeme bilgisi güncellendi.");
		}
	}
}
