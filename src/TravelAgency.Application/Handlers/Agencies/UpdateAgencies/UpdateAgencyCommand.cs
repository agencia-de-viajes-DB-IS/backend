using MediatR;

namespace TravelAgency.Application.Handlers.Agencies.UpdateAgencies;

public class UpdateAgencyCommand : IRequest<UpdateAgencyResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required int FaxNumber { get; set; }
    public required string Email { get; set; }
}