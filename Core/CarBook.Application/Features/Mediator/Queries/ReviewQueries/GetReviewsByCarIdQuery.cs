﻿using CarBook.Application.Features.Mediator.Results.ReviewResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ReviewQueries
{
	public class GetReviewsByCarIdQuery:IRequest<List<GetReviewsByCarIdQueryResult>>
	{
        public int CarId { get; set; }

		public GetReviewsByCarIdQuery(int carId)
		{
			CarId = carId;
		}
	}
}
