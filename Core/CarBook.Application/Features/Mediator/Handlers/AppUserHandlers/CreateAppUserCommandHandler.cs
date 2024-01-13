using CarBook.Application.Enums;
using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook.Application.Interfaces;
using CarBook.Application.Tools;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
	{
		private readonly IRepository<AppUser> _repository;
        private readonly int _iteration = 3;
		private readonly string _pepper = "quaresmakonyasporlularıniçindengeçtigolüattı";
        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
		{
			var user = new AppUser
			{
				UserName = request.UserName,
				PasswordSalt = PasswordHasher.GenerateSalt(),

				AppRoleId = (int)RolesType.Member,
				Email = request.Email,
				Name = request.Name,
				Surname = request.Surname
			};
            user.PasswordHash = PasswordHasher.ComputeHash(request.Password, user.PasswordSalt, _pepper, _iteration);

            await _repository.CreateAsync(user);
		}
	}
}
