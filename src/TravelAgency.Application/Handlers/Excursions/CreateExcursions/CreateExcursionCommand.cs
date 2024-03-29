using MediatR;

namespace TravelAgency.Application.Handlers.Excursions.CreateExcursions;

public class CreateExcursionCommand : IRequest<CreateExcursionResponse>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Location { get; set; }
    public decimal Price { get; set; }
    public required DateTime ArrivalDate { get; set; }
    public required Guid AgencyId { get; set; }
}