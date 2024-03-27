using MediatR;

namespace TravelAgency.Application.Handlers.PackageReservations.CreatePackageReservation;

public record CreatePackageReservationCommand(
    string Airline,
    decimal Price,
    DateTime ReservationDate,
    Guid UserId,
    Guid PackageId,
    IEnumerable<string> TouristIds
) : IRequest<PackageReservationResponse>;

