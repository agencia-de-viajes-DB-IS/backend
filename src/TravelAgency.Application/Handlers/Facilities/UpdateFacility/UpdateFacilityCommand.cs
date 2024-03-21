using MediatR;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;

namespace TravelAgency.Application.Handlers.Facilities.UpdateFacility;

public record UpdateFacilityCommand(
    int Id,
    string Name,
    string Description
) : IRequest<FacilityResponse>;