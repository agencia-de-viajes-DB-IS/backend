using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Application.Responses;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Packages.GetPackages;

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
            .Select(package => new PackageResponse
            {                
                Code = package.Code.ToString(),
                Description = package.Description,
                Price = package.Price,
                ArrivalDate = package.ArrivalDate,
                DepartureDate = package.DepartureDate,
                Facilities = package.Facilities!.Select(facility => new FacilityResponse(
                    facility.Id,
                    facility.Name,
                    facility.Description
                )),
                ExtendedExcursions = package.ExtendedExcursions!.Select(excursion => new ExtendedExcursionResponse(
                    excursion.Id,
                    excursion.Location,
                    excursion.Price,
                    excursion.ArrivalDate,
                    excursion.DepartureDate
                ))
        });
        return response;
    }
}