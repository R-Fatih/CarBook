using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CommentChildrenCommands
{
    public class RemoveCommentChildrenCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveCommentChildrenCommand(int id)
        {
            Id = id;
        }
    }
}
