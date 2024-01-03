using CarBook.Application.Features.Mediator.Results.CommentChildrenResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CommentChildrenQueries
{
    public class GetCommentChildrenByCommentQuery:IRequest<List<GetCommentChildrenByCommentQueryResult>>
    {
        public int CommentId { get; set; }

        public GetCommentChildrenByCommentQuery(int commentId)
        {
            CommentId = commentId;
        }
    }
}
