using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly CreateCarCommandHandler _createCommandHandler;
		private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
		private readonly GetCarQueryHandler _getCarQueryHandler;
		private readonly UpdateCarCommandHandler _updateCarCommandHandler;
		private readonly RemoveCarCommandHandler _removeCarCommandHandler;
		private	readonly GetCarWithQueryHandler _getCarWithQueryHandler;
		public CarsController(CreateCarCommandHandler createCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithQueryHandler getCarWithQueryHandler)
		{
			_createCommandHandler = createCommandHandler;
			_getCarByIdQueryHandler = getCarByIdQueryHandler;
			_getCarQueryHandler = getCarQueryHandler;
			_updateCarCommandHandler = updateCarCommandHandler;
			_removeCarCommandHandler = removeCarCommandHandler;
			_getCarWithQueryHandler = getCarWithQueryHandler;
		}
		[HttpGet]
		public async Task<IActionResult> CarList()
		{
			return Ok(await _getCarQueryHandler.Handle());
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCar(int id)
		{
			var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
			return Ok(value);

		}
		[HttpGet("GetCarWithBrand")]
		public IActionResult GetCarWithBrand()
		{
			var value =  _getCarWithQueryHandler.Handle();
			return Ok(value);

		}
		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCarCommand command)
		{
			await _createCommandHandler.Handle(command);
			return Ok("Araba bilgisi eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveCar(int id)
		{
			await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
			return Ok("Araba bilgisi silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
		{
			await _updateCarCommandHandler.Handle(command);
			return Ok("Araba bilgisi güncellendi.");
		}
	}
}
