using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CommentRepositories
{
    public class CommentRepository : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.Select(x=>new Comment
            {
                CommentId = x.CommentId,
                Name = x.Name,
                BlogId = x.BlogId,
                CreatedDate = x.CreatedDate,
                Description = x.Description,    
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

		public List<Comment> GetCommentsByBlogId(int id)
		{
            return _context.Set<Comment>().Where(x => x.BlogId == id).ToList();
		}

		public void Remove(Comment entity)
        {
            _context.Comments.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }
        public int GetCommentCountByBlog(int id)
        {
            return _context.Comments.Where(x=>x.BlogId==id).ToList().Count();
        }
    }
}
