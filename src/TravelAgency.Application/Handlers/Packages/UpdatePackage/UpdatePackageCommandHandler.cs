using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Handlers.Packages.GetPackages;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Packages.UpdatePackage;

public class UpdatePackageCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdatePackageCommand, PackageResponse>
{
    public async Task<PackageResponse> Handle(UpdatePackageCommand request, CancellationToken cancellationToken)
    {
        // Validate request
        var validator = new UpdatePackageCommandValidator();
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

        var packageFilter = new Expression<Func<Package, bool>>[]
        {
            package => package.Code == request.Code
        };

        var package = (await packageRepo.FindAllAsync(filters: packageFilter)).FirstOrDefault() ?? 
            throw new TravelAgencyException(message: "Package was not found", details: $"Package with id {request.Code} was not found", 404);

        var facilities = (await facilityRepo.FindAllAsync(filters: facilityFilter)).ToList();
        var extendedExcursions = (await extendedExcursionRepo.FindAllAsync(filters: excursionFilter)).ToList();

        package.Name = request.Name;
        package.Description = request.Description;
        package.Price = request.Price;
        package.Capacity = request.Capacity;
        package.Facilities = facilities;
        package.ExtendedExcursions = extendedExcursions;

        await packageRepo.UpdateAsync(package);

        await _unitOfWork.SaveAsync();

        var response = new PackageResponse(
            package.Code.ToString(),
            package.Name,
            package.Description,
            package.Price,
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
                excursion.Location,
                excursion.Price,
                excursion.ArrivalDate,
                excursion.DepartureDate
            )).ToArray()
        );
 
        return response;
    }
}