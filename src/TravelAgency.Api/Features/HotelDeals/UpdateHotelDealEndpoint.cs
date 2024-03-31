using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.HotelDeals.Commands.Update;

namespace TravelAgency.Api.Features.HotelDeals;

public class UpdateHotelDealEndpoint(ISender _mediator) : Endpoint<UpdateHotelDealCommand, UpdateHotelDealResponse>
{
    public override void Configure()
    {
        Put("/hotelDeals");
        // TODO: auth
        AllowAnonymous();
    }
    public override async Task HandleAsync(UpdateHotelDealCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}