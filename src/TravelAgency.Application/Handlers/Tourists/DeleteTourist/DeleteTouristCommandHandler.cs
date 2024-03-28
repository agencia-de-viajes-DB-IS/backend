using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Handlers.Tourists.DeleteTourist;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Tourists.DeleteTourist;

public class DeleteTouristCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteTouristCommand, DeleteTouristResponse>
{
    public async Task<DeleteTouristResponse> Handle(DeleteTouristCommand request, CancellationToken cancellationToken)
    {
        var touristRepo = _unitOfWork.GetRepository<Tourist>();

        var touristFilter = new Expression<Func<Tourist, bool>>[]
        {
            tourist => tourist.Id == request.Id
        };

        if((await touristRepo.FindAsync(filters: touristFilter)) is null)
            throw new TravelAgencyException("Tourist was not found", $"Tourist with Id {request.Id} was not found", 404);

        await touristRepo.DeleteAsync(request.Id);
        await _unitOfWork.SaveAsync();

        var response = new DeleteTouristResponse(request.Id);

        return response;
    }
}