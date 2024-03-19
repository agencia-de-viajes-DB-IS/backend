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
        var validator = new CreatePackageCommandValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            var failedResponse = new PackageResponse
            {
                Success = false,
                ValidationErrors = new List<string>()
            };

            foreach (var error in validationResult.Errors)
                failedResponse.ValidationErrors.Add(error.ErrorMessage);
        }

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
            Description = request.Description,
            Price = request.Price,
            ArrivalDate = request.ArrivalDate,
            DepartureDate = request.DepartureDate,
            Facilities = facilities,
            ExtendedExcursions = extendedExcursions
        };

        await packageRepo.InsertAsync(package);

        await _unitOfWork.SaveAsync();

        var response = new PackageResponse
        {
            Code = package.Code.ToString(),
            Description = package.Description,
            Price = package.Price,
            ArrivalDate = package.ArrivalDate,
            DepartureDate = package.DepartureDate,
            Facilities = facilities.Select(facility => new FacilityResponse(
                facility.Id,
                facility.Name,
                facility.Description
            )),
            ExtendedExcursions = extendedExcursions.Select(excursion => new ExtendedExcursionResponse(
                excursion.Id,
                excursion.Location,
                excursion.Price,
                excursion.ArrivalDate,
                excursion.DepartureDate
            ))
        };

        return response;
    }
}