
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Handlers.ServiceHandlers;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ServicesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> ServiceList()
		{
			return Ok(await _mediator.Send(new GetServiceQuery()));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetService(int id)
		{
			return Ok(await _mediator.Send(new GetServiceByIdQuery(id)));
		}
		[HttpPost]
		public async Task<IActionResult> CreateService(CreateServiceCommand command)
		{
			await _mediator.Send(command);
			return Ok("Hizmet bilgisi eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveService(int id)
		{
			await _mediator.Send(new RemoveServiceCommand(id));
			return Ok("Hizmet bilgisi silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
		{
			await _mediator.Send(command);
			return Ok("Hizmet bilgisi güncellendi.");
		}
	}
}
