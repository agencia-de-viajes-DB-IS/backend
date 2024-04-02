using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;

namespace TravelAgency.Application.Handlers.HotelDealReservations.Commands.Create;
public record CreateHotelDealReservationCommand(
    Guid AirlineId,
    decimal Price,
    DateTime ReservationDate,
    Guid UserId,
    Guid PackageId,
    IEnumerable<Guid> TouristsGuid, 
    Guid AgencyRelatedHotelDealId 
) : IRequest<CreateHotelDealReservationResponse>{}

