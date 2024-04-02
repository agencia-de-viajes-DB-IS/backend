using TravelAgency.Application.Handlers.Airlines.GetAirlines;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Handlers.Users.GetUsers;

namespace TravelAgency.Application.Handlers.PackageReservations.GetPackageReservations;

public record GetPackageReservationsResponse(
    Guid Id,
    UserResponse User,
    PackageResponseOnReservation Package,
    AirlineResponse Airline,
    DateTime ReservationDate,
    decimal Price,
    TouristResponse[] Tourists
);

public record PackageResponseOnReservation(
    string Code,
    string Name,
    string Description,
    decimal Price
);