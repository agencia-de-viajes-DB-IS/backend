using MediatR;
using TravelAgency.Application.Handlers.Airlines.GetAirlines;
using TravelAgency.Application.Handlers.Excursions.GetExcursions;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Handlers.Users.GetUsers;

namespace TravelAgency.Application.Handlers.ExcursionReservations.GetExcursionRerservation;

public class GetExcursionReservationCommand : IRequest<GetExcursionRerservationResponse[]>
{
    public Guid UserIdFilter { get; set; } = default;
    public Guid AirlineIdFilter { get; set; } = default;
    public decimal PriceFilter { get; set; } = default;
    public Guid ExcursionIdFilter { get; set; } = default;
    public DateTime ReservationDate { get; set; } = default;
}

public record GetExcursionRerservationResponse
(
    Guid Id,
    UserResponse User,
    AirlineResponse Airline,
    DateTime ReservationDate,
    ExcursionReservationResponse Excursion,
    decimal Price,
    TouristResponse[] Tourists
);

public record ExcursionReservationResponse
(
    Guid Id,
    string Name,
    string Description
);