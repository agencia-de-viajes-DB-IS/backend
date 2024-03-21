using MediatR;
using TravelAgency.Application.Handlers.Packages.GetPackages;

namespace TravelAgency.Application.Handlers.Packages.CreatePackage;

public record CreatePackageCommand(
    string Description,
    decimal Price,
    DateTime ArrivalDate,
    DateTime DepartureDate,
    IEnumerable<int> FacilityIds,
    IEnumerable<Guid> ExtendedExcursionIds
) : IRequest<PackageResponse>;