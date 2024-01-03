using CarBook.Application.Interfaces.CommentChildrenInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CommentChildrenRepositories
{
    public class CommentChildrenRepository : ICommentChildrenRepository
    {
        private readonly CarBookContext _context;

        public CommentChildrenRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CommentChildren> GetCommentChildrenByComment(int commentId)
        {
            return _context.CommentChildrens.Where(x => x.CommentId == commentId).ToList();
        }
    }
}
