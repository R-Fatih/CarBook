using CarBook.Application.Features.Mediator.Commands.CommentChildrenCommands;
using CarBook.Application.Features.Mediator.Queries.CommentChildrenQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentChildrensController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentChildrensController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CommentChildrenList()
        {
            return Ok(await _mediator.Send(new GetCommentChildrenQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentChildren(int id)
        {
            return Ok(await _mediator.Send(new GetCommentChildrenByIdQuery(id)));
        }
        [HttpGet("GetCommentChildrenByCommentQuery/{id}")]
        public async Task<IActionResult> GetCommentChildrenByComment(int id)
        {
            return Ok(await _mediator.Send(new GetCommentChildrenByCommentQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCommentChildren(CreateCommentChildrenCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt yorum bilgisi eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCommentChildren(int id)
        {
            await _mediator.Send(new RemoveCommentChildrenCommand(id));
            return Ok("Alt yorum bilgisi silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCommentChildren(UpdateCommentChildrenCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt yorum bilgisi güncellendi.");
        }
    }
}
