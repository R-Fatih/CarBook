
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TestimonialsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> TestimonialList()
		{
			return Ok(await _mediator.Send(new GetTestimonialQuery()));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetTestimonial(int id)
		{
			return Ok(await _mediator.Send(new GetTestimonialByIdQuery(id)));
		}
		[HttpPost]
		public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
		{
			await _mediator.Send(command);
			return Ok("Referans bilgisi eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveTestimonial(int id)
		{
			await _mediator.Send(new RemoveTestimonialCommand(id));
			return Ok("Referans bilgisi silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
		{
			await _mediator.Send(command);
			return Ok("Referans bilgisi güncellendi.");
		}
	}
}
