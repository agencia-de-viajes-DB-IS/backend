using MediatR;

namespace TravelAgency.Application.Handlers.Facilities.GetFacilities;

public record GetFacilitiesCommand : IRequest<IEnumerable<FacilityResponse>>;