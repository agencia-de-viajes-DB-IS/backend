using MediatR;

namespace TravelAgency.Application.Handlers.Packages.DeletePackage;

public record DeletePackageCommand(
    Guid Code
) : IRequest<DeletePackageResponse>;