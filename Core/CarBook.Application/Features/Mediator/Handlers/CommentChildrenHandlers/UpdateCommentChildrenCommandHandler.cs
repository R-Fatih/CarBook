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
    public class UpdateCommentChildrenCommandHandler:IRequestHandler<UpdateCommentChildrenCommand>
    {
        private readonly IRepository<CommentChildren> _repository;

        public UpdateCommentChildrenCommandHandler(IRepository<CommentChildren> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCommentChildrenCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.CommentChildrenId);
            values.Description = request.Description;
            values.CreatedDate = request.CreatedDate;
            values.CommentId = request.CommentId;
            values.Email = request.Email;
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
