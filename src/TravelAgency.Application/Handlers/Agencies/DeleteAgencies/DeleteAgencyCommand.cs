using MediatR;

namespace TravelAgency.Application.Handlers.Agencies.DeleteAgencies;

public class DeleteAgencyCommand : IRequest<DeleteAgencyResponse>
{
    public required Guid Id { get; set; }    
}