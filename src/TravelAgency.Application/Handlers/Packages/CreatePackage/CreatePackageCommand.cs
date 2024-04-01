using MediatR;
using TravelAgency.Application.Handlers.Packages.GetPackages;

namespace TravelAgency.Application.Handlers.Packages.CreatePackage;

public record CreatePackageCommand(
    string Name,
    string Description,
    decimal Price,
    DateTime ArrivalDate,
    DateTime DepartureDate,
    int Capacity,
    IEnumerable<int> FacilityIds,
    IEnumerable<Guid> ExtendedExcursionIds
) : IRequest<PackageResponse>;