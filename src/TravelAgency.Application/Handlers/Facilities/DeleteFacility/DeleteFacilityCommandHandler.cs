using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Agencies.CreateAgencies;
using TravelAgency.Application.Handlers.Facilities.DeleteFacility;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Facilities.DeleteFacility;

public class DeleteFacilityCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteFacilityCommand, DeleteFacilityResponse>
{
    public async Task<DeleteFacilityResponse> Handle(DeleteFacilityCommand request, CancellationToken cancellationToken)
    {
        var facilityRepo = _unitOfWork.GetRepository<Facility>();

        var facilityFilter = new Expression<Func<Facility, bool>>[]
        {
            facility => facility.Id == request.Id
        };

        var facility = (await facilityRepo.FindAllAsync(filters: facilityFilter)).FirstOrDefault() ?? 
            throw new TravelAgencyException("Facility was not found", $"Facility with Id {request.Id} was not found", 404);

        await facilityRepo.DeleteAsync(request.Id);
        await _unitOfWork.SaveAsync();

        var response = new DeleteFacilityResponse(request.Id);

        return response;
    }
}