
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Handlers.BlogHandlers;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BlogsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> BlogList()
		{
			return Ok(await _mediator.Send(new GetBlogQuery()));
		}
        [HttpGet("GetLast3BlogsWithAuthors")]
        public async Task<IActionResult> GetLast3BlogsWithAuthors()
        {
            return Ok(await _mediator.Send(new GetLast3BlogsWithAuthorsQuery()));
        }
        [HttpGet("GetAllBlogsWithAuthor")]
        public async Task<IActionResult> GetAllBlogsWithAuthor()
        {
            return Ok(await _mediator.Send(new GetAllBlogsWithAuthorQuery()));
        }
        [HttpGet("{id}")]
		public async Task<IActionResult> GetBlog(int id)
		{
			return Ok(await _mediator.Send(new GetBlogByIdQuery(id)));
		}
		[HttpPost]
		public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
		{
			await _mediator.Send(command);
			return Ok("Blog bilgisi eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveBlog(int id)
		{
			await _mediator.Send(new RemoveBlogCommand(id));
			return Ok("Blog bilgisi silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
		{
			await _mediator.Send(command);
			return Ok("Blog bilgisi güncellendi.");
		}
	}
}
