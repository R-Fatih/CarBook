using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CarBook.WebApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IMediator _mediator;
        public async Task SendStatistics()
        {
            var value = await _mediator.Send(new GetCarCountQuery());
            await Clients.All.SendAsync("ReceiveCarCountQuery", value);
            var value2 = await _mediator.Send(new GetLocationCountQuery());
            await Clients.All.SendAsync("ReceiveLocationCountQuery", value2);
            var value3 = await _mediator.Send(new GetAuthorCountQuery());
            await Clients.All.SendAsync("ReceiveAuthorCountQuery", value3);
            var value4 = await _mediator.Send(new GetBlogCountQuery());
            await Clients.All.SendAsync("ReceiveBlogCountQuery", value4);
            var value5 = await _mediator.Send(new GetBrandCountQuery());
            await Clients.All.SendAsync("ReceiveBrandCountQuery", value5);
            var value6 = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            await Clients.All.SendAsync("ReceiveAvgRentPriceForDailyQuery", value6);
            var value7 = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            await Clients.All.SendAsync("ReceiveAvgRentPriceForWeeklyQuery", value7);
            var value8 = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            await Clients.All.SendAsync("ReceiveAvgRentPriceForMonthlyQuery", value8);
            var value9 = await _mediator.Send(new GetCarCountByTranmissionIsAutoQuery());
            await Clients.All.SendAsync("ReceiveCarCountByTranmissionIsAutoQuery", value9);
            var value10 = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            await Clients.All.SendAsync("ReceiveBrandNameByMaxCarQuery", value10);
            var value11 = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            await Clients.All.SendAsync("ReceiveBlogTitleByMaxBlogCommentQuery", value11);
            var value12 = await _mediator.Send(new GetCarCountByKmSmallerThen1000Query());
            await Clients.All.SendAsync("ReceiveCarCountByKmSmallerThen1000Query", value12);
            var value13 = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            await Clients.All.SendAsync("ReceiveCarCountByFuelGasolineOrDieselQuery", value13);
            var value14 = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            await Clients.All.SendAsync("ReceiveCarCountByFuelElectricQuery", value14);
            var value15 = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            await Clients.All.SendAsync("ReceiveCarBrandAndModelByRentPriceDailyMaxQuery", value15);
            var value16 = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            await Clients.All.SendAsync("ReceiveCarBrandAndModelByRentPriceDailyMinQuery", value16);

        }
        public SignalRHub(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
