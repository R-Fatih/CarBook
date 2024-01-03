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
    public class GetCommentChildrenHandler : IRequestHandler<GetCommentChildrenQuery, List<GetCommentChildrenQueryResult>>
    {
        private readonly IRepository<CommentChildren> _repository;

        public GetCommentChildrenHandler(IRepository<CommentChildren> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentChildrenQueryResult>> Handle(GetCommentChildrenQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCommentChildrenQueryResult
            {
                CommentChildrenId = x.CommentChildrenId,
                CommentId = x.CommentId,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Email = x.Email,
                Name = x.Name,
            }).ToList();
        }
    }
}
