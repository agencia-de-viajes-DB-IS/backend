using MediatR;

namespace TravelAgency.Application.Handlers.ExtendedExcursions.UpdateExtendedExcursions;

public class UpdateExtendedExcursionCommand : IRequest<UpdateExtendedExcursionResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Location { get; set; }
    public decimal Price { get; set; }
    public required DateTime ArrivalDate { get; set; }
    public required DateTime DepartureDate { get; set; }
    public required IEnumerable<Guid> HotelDealsIDs { get; set; }
}