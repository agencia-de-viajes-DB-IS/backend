using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Agencies.CreateAgencies;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Facilities.UpdateFacility;

public class UpdateFacilityCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateFacilityCommand, FacilityResponse>
{
    public async Task<FacilityResponse> Handle(UpdateFacilityCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateFacilityCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            var failedResponse = new FacilityResponse
            {
                Success = false,
                ValidationErrors = new List<string>()
            };

            foreach (var error in validationResult.Errors)
                failedResponse.ValidationErrors.Add(error.ErrorMessage);

            return failedResponse;
        }

        var facilityRepo = _unitOfWork.GetRepository<Facility>();

        var facilityFilter = new Expression<Func<Facility, bool>>[]
        {
            facility => facility.Id == request.Id
        };

        var facility = (await facilityRepo.FindAllAsync(filters: facilityFilter)).FirstOrDefault() ?? 
            throw new TravelAgencyException("Facility was not found", $"Facility with Id {request.Id} was not found", 404);

        facility.Name = request.Name;
        facility.Description = request.Description;
        await facilityRepo.UpdateAsync(facility);
        await _unitOfWork.SaveAsync();

        var response = new FacilityResponse()
        {
            Id = facility.Id,
            Name = facility.Name,
            Description = facility.Description
        };

        return response;
    }
}