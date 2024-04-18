using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.HotelDeals.Queries.GetAll;

public class GetHotelsDealsQueryHandler : IRequestHandler<GetHotelsDealsQuery, HotelsDealsResponse[]>
{
    private readonly IUnitOfWork unitOfWork;

    public GetHotelsDealsQueryHandler(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<HotelsDealsResponse[]> Handle(GetHotelsDealsQuery request, CancellationToken cancellationToken)
    {
        var hotelsDealsRepo = unitOfWork.GetRepository<HotelDeal>();
        var hotelsDealsIncludes = new Expression<Func<HotelDeal, object>>[]
        {
            HotelsDeals => HotelsDeals.ExtendedExcursions!,
            HotelsDeals => HotelsDeals.AgencyRelatedHotelDeals!,
        };
        var response = (await hotelsDealsRepo.FindAllAsync(includes: hotelsDealsIncludes))
            .Select(HotelsDeals => new HotelsDealsResponse(
                HotelsDeals.Id,
                HotelsDeals.HotelId,
                HotelsDeals.Name, 
                HotelsDeals.Description, 
                HotelsDeals.Price,
                HotelsDeals.Capacity,
                HotelsDeals.ArrivalDate, 
                HotelsDeals.DepartureDate,
                [.. HotelsDeals.AgencyRelatedHotelDeals!]
        ));
        return [..response];
    }
}