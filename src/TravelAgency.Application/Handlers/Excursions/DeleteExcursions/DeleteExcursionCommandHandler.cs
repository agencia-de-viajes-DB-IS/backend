using MediatR;
using TravelAgency.Application.Handlers.Agencies.DeleteAgencies;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Excursions.DeleteExcursions;

public class DeleteExcursionCommandHandler(IUnitOfWork iunitOfWork)
    : IRequestHandler<DeleteExcursionCommand, DeleteExcursionResponse>
{
    public async Task<DeleteExcursionResponse> Handle(DeleteExcursionCommand request, CancellationToken cancellationToken)
    {
        await iunitOfWork.GetRepository<Excursion>().DeleteAsync(request.Id);
        await iunitOfWork.SaveAsync();
        var resp = new DeleteExcursionResponse
        {
            Success = true
        };
        return resp;
    }
}