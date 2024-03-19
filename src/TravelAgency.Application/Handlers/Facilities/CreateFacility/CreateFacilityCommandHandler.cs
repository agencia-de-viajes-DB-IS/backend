using MediatR;
using TravelAgency.Application.Handlers.Agencies.CreateAgencies;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Facilities.CreateFacility;

public class CreateFacilityCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateFacilityCommand, FacilityResponse>
{
    public async Task<FacilityResponse> Handle(CreateFacilityCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateFacilityCommandValidator();
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

        var facility = new Facility()
        {
            Name = request.Name,
            Description = request.Description
        };

        await facilityRepo.InsertAsync(facility);
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