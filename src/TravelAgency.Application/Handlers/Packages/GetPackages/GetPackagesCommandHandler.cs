using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Packages.GetPackages;

public class GetPackagesCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetPackagesCommand, PackageResponse[]>
{
    public async Task<PackageResponse[]> Handle(GetPackagesCommand request, CancellationToken cancellationToken)
    {
        var packageRepo = _unitOfWork.GetRepository<Package>();

        var packageFilters = new Expression<Func<Package, bool>>[]
        {
            package => package.ArrivalDate > DateTime.Now,
            package => request.PriceFilter == default || package.Price == request.PriceFilter,
            package => request.ArrivalDateFilter == default || package.ArrivalDate == request.ArrivalDateFilter,
            package => request.DepartureDateFilter == default || package.DepartureDate == request.DepartureDateFilter
        };
        
        var packageIncludes = new Expression<Func<Package, object>>[]
        {
            package => package.Facilities!,
            package => package.ExtendedExcursions!
        };

        var response = (await packageRepo.FindAllAsync(includes: packageIncludes, filters: packageFilters))
            .Select(package => new PackageResponse(
                package.Code.ToString(),
                package.Name,
                package.Description,
                package.Price,
                package.ArrivalDate,
                package.DepartureDate,
                package.Facilities!.Select(facility => new FacilityResponse()
                {
                    Id = facility.Id,
                    Name = facility.Name,
                    Description = facility.Description
                }).ToArray(),
                package.ExtendedExcursions!.Select(excursion => new ExtendedExcursionResponse(
                    excursion.Id,
                    excursion.Location,
                    excursion.Price,
                    excursion.ArrivalDate,
                    excursion.DepartureDate
                )).ToArray()
            )).ToArray();

        return response;
    }
}