using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Tourists.CreateTourist;

public class CreateTouristCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateTouristCommand, TouristResponse>
{
    public async Task<TouristResponse> Handle(CreateTouristCommand request, CancellationToken cancellationToken)
    {
        // Validate request
        var validator = new CreateTouristCommandValidator(_unitOfWork);
        await validator.ValidateAsync(request, cancellationToken);

        var touristRepo = _unitOfWork.GetRepository<Tourist>();
        
        var tourist = new Tourist()
        {
            UserId = request.UserId,
            CI = request.CI,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Nationality = request.Nationality
        };

        await touristRepo.InsertAsync(tourist);
        await _unitOfWork.SaveAsync();

        var response = new TouristResponse(
            request.UserId,
            tourist.Id,
            tourist.CI,
            tourist.FirstName,
            tourist.LastName,
            tourist.Nationality
        );
        return response;
    }
}