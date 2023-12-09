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
	public class GetLast5CarsWithBrandQueryHandler
    {
		private readonly ICarRepository _repository;

		public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public  List<GetLast5CarsWithBrandQueryResult> Handle()
		{
			var values =  _repository.GetLast5CarsWithBrands();
			return values.Select(x => new GetLast5CarsWithBrandQueryResult
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
