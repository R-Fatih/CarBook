using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarBook.Application.Features.Mediator.Commands.ReviewCommands;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetReviewByCarId(int id)
		{
			return Ok(await _mediator.Send(new GetReviewsByCarIdQuery(id)));
		}
		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand command)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			await _mediator.Send(command);
			return Ok("Yorum bilgisi eklendi.");
		}
		
		[HttpPut]
		public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
		{
			if (!ModelState.IsValid)
			{
				
				return BadRequest(ModelState);
			}
			await _mediator.Send(command);
			return Ok("Yorum bilgisi güncellendi.");
		}
	}
}
