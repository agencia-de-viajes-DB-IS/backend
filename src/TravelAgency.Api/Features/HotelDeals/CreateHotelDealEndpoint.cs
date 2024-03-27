using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.HotelDeals.Commands.Create;

namespace TravelAgency.Api.Features.HotelDeal;

public class CreateHotelDealEndpoint(ISender _mediator) : Endpoint<CreateHotelDealCommand, CreateHotelDealResponse>
{
    public override void Configure()
    {
        Post("/hotelDeals");
        // TODO: auth
        AllowAnonymous();
    }
    public override async Task HandleAsync(CreateHotelDealCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}