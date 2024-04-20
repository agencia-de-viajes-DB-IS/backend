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
        var AgencyRelatedHotelDeals = unitOfWork.GetRepository<AgencyRelatedHotelDeal>();
        var agencyRelatedHotelDealsIncludes = new Expression<Func<AgencyRelatedHotelDeal, object>>[]
        {
            HotelsDeals => HotelsDeals.HotelDeal,
            HotelsDeals => HotelsDeals.Agency,
        };

        var agencyRelatedHotelDealsFilters = new Expression<Func<AgencyRelatedHotelDeal, bool>>[]
        {
            agencyRelatedHotelDeals => request.AgencyIdFilter == null || agencyRelatedHotelDeals.AgencyId == request.AgencyIdFilter,
        };

        var response = (await AgencyRelatedHotelDeals.FindAllAsync(includes: agencyRelatedHotelDealsIncludes, filters: agencyRelatedHotelDealsFilters))
            .Select(HotelsDeals => new HotelsDealsResponse(
                HotelsDeals.Id,
                HotelsDeals.HotelDeal.HotelId,
                HotelsDeals.HotelDeal.Name, 
                HotelsDeals.HotelDeal.Description, 
                HotelsDeals.HotelDeal.Price,
                HotelsDeals.HotelDeal.Capacity,
                HotelsDeals.HotelDeal.ArrivalDate, 
                HotelsDeals.HotelDeal.DepartureDate,
                new AgencyRelatedHotelDealDto(
                    HotelsDeals.AgencyId,
                    HotelsDeals.Agency.Name
                )
        ));
        return [..response];
    }
}