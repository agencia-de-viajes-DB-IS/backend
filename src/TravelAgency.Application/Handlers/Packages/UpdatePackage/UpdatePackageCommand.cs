using MediatR;
using TravelAgency.Application.Handlers.Packages.GetPackages;

namespace TravelAgency.Application.Handlers.Packages.UpdatePackage;

public record UpdatePackageCommand(
    Guid Code,
    string Name, 
    string Description,
    decimal Price,
    IEnumerable<int> FacilityIds,
    IEnumerable<Guid> ExtendedExcursionIds
) : IRequest<PackageResponse>;