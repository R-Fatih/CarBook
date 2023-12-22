﻿using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator medaitor)
        {
            _mediator = medaitor;
        }
        [HttpGet("GetCarCount")]
        public async Task< IActionResult> GetCarCount()
        {
            var value =await _mediator.Send(new GetCarCountQuery());
            return Ok(value);

        }
    }
}