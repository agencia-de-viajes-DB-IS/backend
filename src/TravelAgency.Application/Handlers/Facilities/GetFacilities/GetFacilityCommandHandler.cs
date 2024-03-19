using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Facilities.GetFacilities;

public class GetFacilityCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetFacilitiesCommand, IEnumerable<FacilityResponse>>
{
    public async Task<IEnumerable<FacilityResponse>> Handle(GetFacilitiesCommand request, CancellationToken cancellationToken)
    {
        var facilityRepo = _unitOfWork.GetRepository<Facility>();

        var facilities = await facilityRepo.FindAllAsync();
        
        var response = facilities.Select(facility => new FacilityResponse(
            facility.Id,
            facility.Name,
            facility.Description
        ));

        return response;
    }
}