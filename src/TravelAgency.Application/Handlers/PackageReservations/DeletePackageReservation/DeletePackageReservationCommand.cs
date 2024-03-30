using MediatR;

namespace TravelAgency.Application.Handlers.PackageReservations.DeletePackageReservation;

public record DeletePackageReservationCommand(
    Guid Id
) : IRequest<DeletePackageReservationResponse>;