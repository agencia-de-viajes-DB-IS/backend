using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;

namespace TravelAgency.Application.Handlers.PackageReservations.CreatePackageReservation;

public record CreatePackageReservationCommand(
    string Airline,
    decimal Price,
    DateTime ReservationDate,
    Guid UserId,
    Guid PackageId,
    IEnumerable<CreateTouristCommand> Tourists
) : IRequest<PackageReservationResponse>;

