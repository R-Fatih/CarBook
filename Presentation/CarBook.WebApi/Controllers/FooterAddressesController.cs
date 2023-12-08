
using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterAddressesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FooterAddressesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> FooterAddressList()
		{
			return Ok(await _mediator.Send(new GetFooterAddressQuery()));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetFooterAddress(int id)
		{
			return Ok(await _mediator.Send(new GetFooterAddressByIdQuery(id)));
		}
		[HttpPost]
		public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
		{
			await _mediator.Send(command);
			return Ok("Footer Adres bilgisi eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveFooterAddress(int id)
		{
			await _mediator.Send(new RemoveFooterAddressCommand(id));
			return Ok("Footer Adres bilgisi silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
		{
			await _mediator.Send(command);
			return Ok("Footer Adres bilgisi güncellendi.");
		}
	}
}
