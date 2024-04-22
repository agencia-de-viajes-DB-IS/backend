using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Handlers.Packages.GetPackages;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Packages.CreatePackage;

public class CreatePackageCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreatePackageCommand, PackageResponse>
{
    public async Task<PackageResponse> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
    {
        // Validate request
        var validator = new CreatePackageCommandValidator(_unitOfWork);
        await validator.ValidateAsync(request, cancellationToken);

        var facilityRepo = _unitOfWork.GetRepository<Facility>();
        var extendedExcursionRepo = _unitOfWork.GetRepository<ExtendedExcursion>();
        var packageRepo = _unitOfWork.GetRepository<Package>();

        var facilityFilter = new Expression<Func<Facility, bool>>[]
        {
            facility => request.FacilityIds.Contains(facility.Id)
        };

        var excursionFilter = new Expression<Func<ExtendedExcursion, bool>>[]
        {
            excursion => request.ExtendedExcursionIds.Contains(excursion.Id)
        };

        var facilities = (await facilityRepo.FindAllAsync(filters: facilityFilter)).ToList();
        var extendedExcursions = (await extendedExcursionRepo.FindAllAsync(filters: excursionFilter)).ToList();

        var package = new Package()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            ArrivalDate = request.ArrivalDate,
            DepartureDate = request.DepartureDate,
            Capacity = request.Capacity,
            Facilities = facilities,
            ExtendedExcursions = extendedExcursions
        };

        await packageRepo.InsertAsync(package);

        await _unitOfWork.SaveAsync();

        var response = new PackageResponse(
            package.Code.ToString(),
            package.Name,
            package.Description,
            package.Price,
            package.Capacity,
            (package.ExtendedExcursions!.Count == 0) ? default : package.ExtendedExcursions!.First().AgencyId,
            package.ArrivalDate,
            package.DepartureDate,
            facilities.Select(facility => new FacilityResponse()
            {
                Id = facility.Id,
                Name = facility.Name,
                Description = facility.Description
            }).ToArray(),
            extendedExcursions.Select(excursion => new ExtendedExcursionResponse(
                excursion.Id,
                excursion.Name,
                excursion.Location,
                excursion.Price,
                excursion.ArrivalDate,
                excursion.DepartureDate
            )).ToArray()
        );

        return response;
    }
}