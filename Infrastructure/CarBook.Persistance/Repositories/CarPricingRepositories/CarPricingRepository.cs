using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository:ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarsPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(y => y.Pricing).Where(z=>z.PricingId==1).ToList();
            return values;
        }

		public List<GetCarPricingWithTimePeriodQueryResult> GetCarsPricingWithTimePeriod()
		{
           var values= _context.Database.SqlQueryRaw<GetCarPricingWithTimePeriodQueryResult>("select Model,[2] as 'DailyAmount',[3] as 'WeeklyAmount',[5] as 'MonthlyAmount' from\r\n(select Brands.Name+' '+Model as Model,Pricings.PricingId,Amount from CarPricings inner join Cars on Cars.CarId=CarPricings.CarId inner join Brands on Cars.BrandId=Brands.BrandId inner join Pricings on Pricings.PricingId=CarPricings.PricingId) as Source_table\r\nPivot(\r\nSum(Amount) For PricingId in ([2],[3],[5])\r\n) as Pivot_table").ToList();
            return values;
        }
	}
}
