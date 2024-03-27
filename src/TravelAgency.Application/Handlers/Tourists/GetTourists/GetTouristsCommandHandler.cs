using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Tourists.GetTourists;

public class GetTouristsCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetTouristsCommand, TouristResponse[]>
{
    public async Task<TouristResponse[]> Handle(GetTouristsCommand request, CancellationToken cancellationToken)
    {
        var touristRepo = _unitOfWork.GetRepository<Tourist>();

        var tourists = await touristRepo.FindAllAsync();

        var response = tourists.Select(tourist => new TouristResponse(
            tourist.Id,
            tourist.FirstName,
            tourist.LastName,
            tourist.Nationality
        )).ToArray();

        return response;
    }
}