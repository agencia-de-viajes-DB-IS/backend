using MediatR;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Packages.GetPackages;

public record GetPackagesCommand : IRequest<IEnumerable<PackageResponse>>;