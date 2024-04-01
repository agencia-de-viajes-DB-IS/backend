using MediatR;

namespace TravelAgency.Application.Handlers.ExtendedExcursions.DeleteExtendedExcursions;

public class DeleteExtendedExcursionCommand : IRequest<DeleteExtendedExcursionResponse>
{
    public required Guid Id { get; set; }
}
