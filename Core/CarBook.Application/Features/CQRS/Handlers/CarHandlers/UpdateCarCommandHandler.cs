using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class UpdateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public UpdateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateCarCommand updateCarCommand)
		{
			await _repository.UpdateAsync(new Car
			{
				BigImageUrl = updateCarCommand.BigImageUrl,
				BrandId = updateCarCommand.BrandId,
				CoverImageUrl = updateCarCommand.CoverImageUrl,
				Fuel = updateCarCommand.Fuel,
				Transmission = updateCarCommand.Transmission,
				Seat = updateCarCommand.Seat,
				Model = updateCarCommand.Model,
				Luggage = updateCarCommand.Luggage,
				Km = updateCarCommand.Km,
				CarId =updateCarCommand.CarId
			});
		}
	}
}
