using CarBook.Application.Features.Mediator.Results.CarFeaturesResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery:IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public int CarId { get; set; }

        public GetCarFeatureByCarIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
