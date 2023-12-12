using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository:IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogsWithAuthor()
        {
            var values = _context.Blogs.Include(x => x.Author).ToList();
            return values;
        }

        public List<Blog> GetBlogByAuthorId(int id)
        {
            var values = _context.Blogs.Include(x => x.Author).Where(a => a.BlogId == id).ToList();
            return values;
        }

        public List<Blog> GetLast3BlogsWithAuthors()
        {
            var values=_context.Blogs.Include(x=>x.Author).OrderByDescending(x=>x.BlogId).Take(3).ToList();
            return values;
        }
    }
}
