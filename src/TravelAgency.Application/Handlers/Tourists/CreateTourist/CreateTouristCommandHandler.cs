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
        var validator = new CreateTouristCommandValidator();
        await validator.ValidateAsync(request, cancellationToken);

        var touristRepo = _unitOfWork.GetRepository<Tourist>();

        var touristFilter = new Expression<Func<Tourist, bool>>[]
        {
            tourist => tourist.Id == request.Id
        };

        if((await touristRepo.FindAsync(filters:touristFilter)) is not null)
            throw new TravelAgencyException("Tourist's Id is already registered", $"Id {request.Id} is already registered", status: 400);

        var tourist = new Tourist()
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Nationality = request.Nationality
        };

        await touristRepo.InsertAsync(tourist);
        await _unitOfWork.SaveAsync();

        var response = new TouristResponse(
            tourist.Id,
            tourist.FirstName,
            tourist.LastName,
            tourist.Nationality
        );

        return response;
    }
}