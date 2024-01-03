using CarBook.Application.Features.Mediator.Queries.CommentChildrenQueries;
using CarBook.Application.Features.Mediator.Results.CommentChildrenResults;
using CarBook.Application.Interfaces.CommentChildrenInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentChildrenHandlers
{
    public class GetCommentChildrenByCommentQueryHandler : IRequestHandler<GetCommentChildrenByCommentQuery, List<GetCommentChildrenByCommentQueryResult>>
    {
        private readonly ICommentChildrenRepository _repository;

        public GetCommentChildrenByCommentQueryHandler(ICommentChildrenRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentChildrenByCommentQueryResult>> Handle(GetCommentChildrenByCommentQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCommentChildrenByComment(request.CommentId);
            return values.Select(x => new GetCommentChildrenByCommentQueryResult
            {
                CommentId = request.CommentId,
                CommentChildrenId = x.CommentChildrenId,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Email = x.Email,
                Name = x.Name
            }).ToList();
        }
    }
}
