using CarBook.Application.Features.Mediator.Queries.CommentChildrenQueries;
using CarBook.Application.Features.Mediator.Results.CommentChildrenResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentChildrenHandlers
{
    public class GetCommentChildrenByIdQueryHandler : IRequestHandler<GetCommentChildrenByIdQuery, GetCommentChildrenByIdQueryResult>
    {
        private readonly IRepository<CommentChildren> _repository;

        public GetCommentChildrenByIdQueryHandler(IRepository<CommentChildren> repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentChildrenByIdQueryResult> Handle(GetCommentChildrenByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            return new GetCommentChildrenByIdQueryResult
            {
                CommentChildrenId = value.CommentChildrenId,
                CommentId = value.CommentId,
                CreatedDate = value.CreatedDate,
                Description = value.Description,
                Email = value.Email,
                Name = value.Name,
            };
        }
    }
}
