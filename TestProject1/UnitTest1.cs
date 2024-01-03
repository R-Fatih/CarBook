using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using MediatR;
using Moq;
using System.Collections.ObjectModel;

namespace TestProject1
{
    public class UnitTest1
    {

        private readonly Mock<IRepository<Car>> _repository;
        public UnitTest1()
        {
            _repository = new();
        }




        [Fact]
        public async Task GetAllTodoListsTest()
        {

            var command = new CreateCarCommand();
            var handler = new CreateCarCommandHandler(_repository.Object);

            //act

             var result= handler.Handle(command);
            Assert.True(result.IsCompletedSuccessfully);
        }
    }
}