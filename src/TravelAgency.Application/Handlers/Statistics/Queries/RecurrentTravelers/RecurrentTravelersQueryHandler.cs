using System.Security.Authentication;
using MediatR;
using TravelAgency.Application.Handlers.Statistics.Queries.RecurrentTravelers;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;
public class RecurrentTravelersQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<RecurrentTravelersQuery, RecurrentTravelersResponse[]>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<RecurrentTravelersResponse[]> Handle(RecurrentTravelersQuery request, CancellationToken cancellationToken)
    {
        var touristRepo = _unitOfWork.GetRepository<Tourist>(); 
        var tourists = await touristRepo.FindAllAsync(
            includes: [
                x => x.ExcursionReservations,
                x => x.PackageReservations,
                x => x.HotelDealReservations
            ],
            filters: [
            x => x.PackageReservations.Count > 0 || x.HotelDealReservations.Count > 0 || x.ExcursionReservations.Count > 0 
        ]);

        return tourists.GroupBy(x => x.CI).Select(x => new RecurrentTravelersResponse(
            x.First().CI,
            x.First().FirstName,
            x.First().LastName,
            x.Count()
        )).ToArray();        
    }
}
