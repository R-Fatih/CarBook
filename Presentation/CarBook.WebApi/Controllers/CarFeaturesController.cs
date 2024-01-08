using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int carId)
        {
            return Ok(await _mediator.Send(new GetCarFeatureByCarIdQuery(carId)));

        }
        [HttpGet("UpdateCarFeatureAvailableChangeToFalse/{id}")]
        public async Task<IActionResult> UpdateCarFeatureAvailableChangeToFalse(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Başarıyla güncellendi");

        }
        [HttpGet("UpdateCarFeatureAvailableChangeToTrue/{id}")]
        public async Task<IActionResult> UpdateCarFeatureAvailableChangeToTrue(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Başarıyla güncellendi");

        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeature(CreateCarFeatureByCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Tag Cloud bilgisi eklendi.");
        }
    }
}
