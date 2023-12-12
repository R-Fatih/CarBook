
using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagCloudsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TagCloudsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> TagCloudList()
		{
			return Ok(await _mediator.Send(new GetTagCloudQuery()));
		}
        [HttpGet("GetTagCloudByBlogId")]
        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
            return Ok(await _mediator.Send(new GetTagCloudByBlogIdQuery(id)));
        }
        [HttpGet("{id}")]
		public async Task<IActionResult> GetTagCloud(int id)
		{
			return Ok(await _mediator.Send(new GetTagCloudByIdQuery(id)));
		}
		[HttpPost]
		public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
		{
			await _mediator.Send(command);
			return Ok("Tag Cloud bilgisi eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveTagCloud(int id)
		{
			await _mediator.Send(new RemoveTagCloudCommand(id));
			return Ok("Tag Cloud bilgisi silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
		{
			await _mediator.Send(command);
			return Ok("Tag Cloud bilgisi güncellendi.");
		}
	}
}
