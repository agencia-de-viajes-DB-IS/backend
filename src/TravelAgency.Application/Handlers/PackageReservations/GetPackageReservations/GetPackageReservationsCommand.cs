using MediatR;
using TravelAgency.Application.Handlers.PackageReservations.CreatePackageReservation;

namespace TravelAgency.Application.Handlers.PackageReservations.GetPackageReservations;

public record GetPackageReservationsCommand(
    Guid UserIdFilter,
    Guid PackageIdFilter,
    Guid AirlineIdFilter,
    DateTime ReservationDateFilter
) : IRequest<GetPackageReservationsResponse[]>;