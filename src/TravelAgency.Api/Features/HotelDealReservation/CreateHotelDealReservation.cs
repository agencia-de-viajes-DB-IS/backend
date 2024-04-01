using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.HotelDealReservations.Commands.Create;

namespace TravelAgency.Api.Features.HotelDealReservation;

public class CreateHotelDealReservationEndpoint(ISender _mediator) : Endpoint<CreateHotelDealReservationCommand, CreateHotelDealReservationResponse>
{
    public override void Configure()
    {
        Post("/reservation/hotelDeal");
        Permissions("WriteHotelDealReservation");
    }
    public override async Task HandleAsync(CreateHotelDealReservationCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}