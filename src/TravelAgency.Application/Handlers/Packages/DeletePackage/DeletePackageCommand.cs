using MediatR;
using TravelAgency.Application.Handlers.Packages.GetPackages;

namespace TravelAgency.Application.Handlers.Packages.DeletePackage;

public record DeletePackageCommand(
    Guid Code
) : IRequest<DeletePackageResponse>;