using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Application.Responses;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.HotelsDeals.Queries.GetAll;

public class GetHotelsDealsQueryHandler : IRequestHandler<GetHotelsDealsQuery, IEnumerable<HotelsDealsResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetHotelsDealsQueryHandler(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<IEnumerable<HotelsDealsResponse>> Handle(GetHotelsDealsQuery request, CancellationToken cancellationToken)
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
                HotelsDeals.Description, 
                HotelsDeals.Price, 
                HotelsDeals.ArrivalDate, 
                HotelsDeals.DepartureDate
        ));
        return response;
    }
}