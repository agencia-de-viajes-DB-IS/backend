using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Facilities.GetFacilities;

public class GetFacilityCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetFacilitiesCommand, FacilityResponse[]>
{
    public async Task<FacilityResponse[]> Handle(GetFacilitiesCommand request, CancellationToken cancellationToken)
    {
        var facilityRepo = _unitOfWork.GetRepository<Facility>();

        var facilities = await facilityRepo.FindAllAsync();

        var response = facilities.Select(facility => new FacilityResponse()
        {
            Id = facility.Id,
            Name = facility.Name,
            Description = facility.Description
        }).ToArray();

        return response;
    }
}