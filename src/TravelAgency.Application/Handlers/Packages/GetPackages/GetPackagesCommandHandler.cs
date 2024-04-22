using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Packages.GetPackages;

public class GetPackagesCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetPackagesCommand, GetPackageResponse[]>
{
    public async Task<GetPackageResponse[]> Handle(GetPackagesCommand request, CancellationToken cancellationToken)
    {
        var packageRepo = _unitOfWork.GetRepository<Package>();
        var agencyRepo = _unitOfWork.GetRepository<Agency>();

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
        
        var packages = (await packageRepo.FindAllAsync(includes: packageIncludes, filters: packageFilters)).ToArray();

        var tasks = packages
            .Select(async package => new GetPackageResponse(
                package.Code.ToString(),
                package.Name,
                package.Description,
                package.Price,
                package.Capacity,
                (package.ExtendedExcursions!.Count == 0) ? new PackageAgencyResponse(default, "") : await GetPackageAgency(package, agencyRepo),
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
                    excursion.Name,
                    excursion.Location,
                    excursion.Price,
                    excursion.ArrivalDate,
                    excursion.DepartureDate
                )).ToArray()
            ));

        var response = new List<GetPackageResponse>();

        foreach(var task in tasks) {
            task.Wait();
            response.Add(task.Result);
        }

        return response.ToArray();
    }

    private static async Task<PackageAgencyResponse> GetPackageAgency(Package package, IGenericRepository<Agency> agencyRepo)
    {
        var excursion = package.ExtendedExcursions!.First();

        var agency = await agencyRepo.FindAsync(filters: [a => a.Id == excursion.AgencyId]);

        return  (agency is null) ? new PackageAgencyResponse(default, "") : new PackageAgencyResponse(agency.Id, agency.Name);
    }
}