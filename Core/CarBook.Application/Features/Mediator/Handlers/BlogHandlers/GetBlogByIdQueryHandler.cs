﻿using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
	{
		private readonly IRepository<Blog> _repository;
		public GetBlogByIdQueryHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetBlogByIdQueryResult
			{
				BlogId = values.BlogId,
				CategoryId = values.CategoryId,
				CreatedDate = values.CreatedDate,
				Title = values.Title,
				CoverImageUrl	= values.CoverImageUrl,
				AuthorId=values.AuthorId,
			};
		}
	}
}