﻿using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
	public class RemoveBannerCommandHandler
	{
		private readonly IRepository<Banner> _repository;

		public RemoveBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveBannerCommand removeBannerCommand)
		{
			var value = await _repository.GetByIdAsync(removeBannerCommand.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
