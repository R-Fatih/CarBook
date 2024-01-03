using CarBook.Application.Features.Mediator.Results.CommentChildrenResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CommentChildrenQueries
{
    public class GetCommentChildrenByIdQuery:IRequest<GetCommentChildrenByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCommentChildrenByIdQuery(int id)
        {
            Id = id;
        }
    }
}
