using MediatR;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.PackagesHandlers.GetPackages;

public record GetPackagesCommand : IRequest<IEnumerable<PackageResponse>>;