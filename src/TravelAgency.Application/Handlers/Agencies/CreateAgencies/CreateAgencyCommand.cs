using MediatR;

namespace TravelAgency.Application.Handlers.Agencies.CreateAgencies;
public class CreateAgencyCommand : IRequest<CreateAgencyResponse>
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required int FaxNumber { get; set; }
    public required string Email { get; set; }
}