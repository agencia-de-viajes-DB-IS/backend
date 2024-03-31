using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.HotelDeals.Commands.Delete;

namespace TravelAgency.Api.Features.HotelDeals;

public class DeleteHotelDealEndpoint(ISender _mediator) : Endpoint<DeleteHotelDealCommand, DeleteHotelDealResponse>
{
    public override void Configure()
    {
        Delete("/hotelDeals");
        // TODO: auth
        AllowAnonymous();
    }
    public override async Task HandleAsync(DeleteHotelDealCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}