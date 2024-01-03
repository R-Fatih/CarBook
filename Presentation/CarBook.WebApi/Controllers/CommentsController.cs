using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommentsController(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetCommentList()
        {
            var values=_repository.GetAll();
            return Ok(values);
        }
		[HttpGet("GetCommentsByBlogId")]
		public IActionResult GetCommentsByBlogId(int id)
		{
			var values = _repository.GetCommentsByBlogId(id);
			return Ok(values);
		}
        [HttpGet("GetCommentCountByBlog")]
        public IActionResult GetCommentCountByBlog(int id)
        {
            var value = _repository.GetCommentCountByBlog(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _repository.Create(comment);
            return Ok("Başarıyla eklendi");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok("Başarıyla güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _repository.GetById(id);
            _repository.Remove(value);
            return Ok("Başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _repository.GetById(id);
            return Ok(values);
        }
    }
}
