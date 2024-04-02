using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.HotelDealReservations.Queries.GetAll;

namespace TravelAgency.Api.Features.HotelDealReservation;

public class GetAllHotelDealReservationsEndpoint(ISender _mediator) : Endpoint<GetAllHotelDealReservationsQuery, GetAllHotelDealReservationsResponse[]>
{
    public override void Configure()
    {
        Get("/reservation/HotelDeal");
        Permissions("ReadHotelDealReservation");
    }
    public override async Task HandleAsync(GetAllHotelDealReservationsQuery command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}