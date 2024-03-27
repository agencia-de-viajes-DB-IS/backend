using MediatR;

namespace TravelAgency.Application.Handlers.Excursions.DeleteExcursions;

public class DeleteExcursionCommand : IRequest<DeleteExcursionResponse>
{
    public required Guid Id {get;set;}
}