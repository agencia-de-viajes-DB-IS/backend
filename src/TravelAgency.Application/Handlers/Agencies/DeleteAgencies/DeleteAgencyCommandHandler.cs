using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Agencies.DeleteAgencies;

public class DeleteAgencyCommandHandler(IUnitOfWork iunitOfWork)
    : IRequestHandler<DeleteAgencyCommand, DeleteAgencyResponse>
{
    public async Task<DeleteAgencyResponse> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
    {
        await iunitOfWork.GetRepository<Agency>().DeleteAsync(request.Id);
        await iunitOfWork.SaveAsync();
        var resp = new DeleteAgencyResponse
        {
            Success = true
        };
        return resp;
    }
}