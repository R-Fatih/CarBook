using CarBook.Application.Features.Mediator.Commands.CommentChildrenCommands;
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
    public class CreateCommentChildrenCommandHandler : IRequestHandler<CreateCommentChildrenCommand>
    {
        private readonly IRepository<CommentChildren> _repository;

        public CreateCommentChildrenCommandHandler(IRepository<CommentChildren> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCommentChildrenCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CommentChildren
            {
                CommentId = request.CommentId,
                CreatedDate = request.CreatedDate,
                Description = request.Description,
                Email = request.Email,
                Name = request.Name,
            });
        }
    }
}
