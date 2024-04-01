using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.ExtendedExcursions.DeleteExtendedExcursions;

public class DeleteExtendedExcursionCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteExtendedExcursionCommand, DeleteExtendedExcursionResponse>
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;
    public async Task<DeleteExtendedExcursionResponse> Handle(DeleteExtendedExcursionCommand request, CancellationToken cancellationToken)
    {
        var extendedExcursionId = request.Id;
        var extendedExcursionRepo = UnitOfWork.GetRepository<ExtendedExcursion>();
        await extendedExcursionRepo.DeleteAsync(request.Id);
        await UnitOfWork.SaveAsync();
        return new DeleteExtendedExcursionResponse();
    }
}
