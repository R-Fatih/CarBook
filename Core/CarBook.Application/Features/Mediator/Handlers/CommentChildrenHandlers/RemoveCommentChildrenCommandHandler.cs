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
    public class RemoveCommentChildrenCommandHandler:IRequestHandler<RemoveCommentChildrenCommand>
    {
        private readonly IRepository<CommentChildren> _repository;

        public RemoveCommentChildrenCommandHandler(IRepository<CommentChildren> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCommentChildrenCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
