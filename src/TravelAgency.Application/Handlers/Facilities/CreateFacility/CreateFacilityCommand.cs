using MediatR;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;

namespace TravelAgency.Application.Handlers.Facilities.CreateFacility;

public record CreateFacilityCommand(
    string Name,
    string Description
) : IRequest<FacilityResponse>;