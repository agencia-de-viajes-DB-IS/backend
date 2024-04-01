using System.Data;
using MediatR;

namespace TravelAgency.Application.Handlers.ExtendedExcursions.CreateExtendedExcursions;
public class CreateExtendedExcursionCommand : IRequest<CreateExtendedExcursionResponse>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Location { get; set; }
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public required DateTime ArrivalDate { get; set; }
    public required DateTime DepartureDate { get; set; }
    public required IEnumerable<Guid> HotelDealsIDs { get; set; }
    public required Guid AgencyId { get; set; }
}
