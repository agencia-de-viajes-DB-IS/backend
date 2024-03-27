using MediatR;

namespace TravelAgency.Application.Handlers.Facilities.DeleteFacility;

public record DeleteFacilityCommand(
    int Id
) : IRequest<DeleteFacilityResponse> ;