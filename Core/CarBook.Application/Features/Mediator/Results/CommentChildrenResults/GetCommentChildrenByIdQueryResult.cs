using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CommentChildrenResults
{
    public class GetCommentChildrenByIdQueryResult
    {
        public int CommentChildrenId { get; set; }
        public int CommentId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
