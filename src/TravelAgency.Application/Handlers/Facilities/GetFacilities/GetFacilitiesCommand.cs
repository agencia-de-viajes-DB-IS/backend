using MediatR;

namespace TravelAgency.Application.Handlers.Facilities.GetFacilities;

public record GetFacilitiesCommand : IRequest<FacilityResponse[]>;