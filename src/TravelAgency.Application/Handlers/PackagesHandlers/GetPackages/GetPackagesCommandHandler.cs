using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Application.Responses;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.PackagesHandlers.GetPackages;

public class GetPackagesCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetPackagesCommand, IEnumerable<PackageResponse>>
{
    public async Task<IEnumerable<PackageResponse>> Handle(GetPackagesCommand request, CancellationToken cancellationToken)
    {
        var packageRepo = _unitOfWork.GetRepository<Package>();

        var packageIncludes = new Expression<Func<Package, object>>[]
        {
            package => package.Facilities!,
            package => package.ExtendedExcursions!
        };

        var response = (await packageRepo.FindAllAsync(includes: packageIncludes))
            .Select(package => new PackageResponse(
                package.Code.ToString(),
                package.Description,
                package.Price,
                package.ArrivalDate,
                package.DepartureDate,
                package.Facilities!,
                package.ExtendedExcursions!
        ));

        return response;
    }
}
