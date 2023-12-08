using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWithQueryHandler
	{
		private readonly ICarRepository _repository;

		public GetCarWithQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public  List<GetCarWithBrandQueryResult> Handle()
		{
			var values =  _repository.GetCarsListWithBrands();
			return values.Select(x => new GetCarWithBrandQueryResult
			{
				CarId = x.CarId,
				BrandName=x.Brand.Name,
				BigImageUrl = x.BigImageUrl,
				BrandId = x.BrandId,
				CoverImageUrl = x.CoverImageUrl,
				Fuel = x.Fuel,
				Transmission = x.Transmission,
				Seat = x.Seat,
				Model = x.Model,
				Luggage = x.Luggage,
				Km = x.Km
			}).ToList();
		}
	}
}
