using MediatR;

namespace TravelAgency.Application.Handlers.Excursions.UpdateExcursions;

public class UpdateExcursionCommand : IRequest<UpdateExcursionResponse>
{
    public required Guid Id { get; set; }
    
    public required string Location { get; set; }
    public decimal Price { get; set; }
    public DateTime ArrivalDate { get; set; }
}