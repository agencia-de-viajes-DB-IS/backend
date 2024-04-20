using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.HotelDeals.Queries.GetAll;

public class GetHotelsDealsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetHotelsDealsQuery, HotelsDealsResponse[]>
{
    public async Task<HotelsDealsResponse[]> Handle(GetHotelsDealsQuery request, CancellationToken cancellationToken)
    {
        var hotelDealRepo = _unitOfWork.GetRepository<HotelDeal>();
        var agencyRepo = _unitOfWork.GetRepository<Agency>();

        var hotelDealIncludes = new Expression<Func<HotelDeal, object>>[]
        {
            deal => deal.AgencyRelatedHotelDeals!
        };

        var hotelDeals = (await hotelDealRepo.FindAllAsync(includes:hotelDealIncludes)).ToList();

        var agencies = (await agencyRepo.FindAllAsync()).ToList();

        var response = hotelDeals.Select(deal => new HotelsDealsResponse(
            deal.Id,
            deal.HotelId,
            deal.Name,
            deal.Description,
            deal.Price,
            deal.Capacity,
            deal.ArrivalDate,
            deal.DepartureDate,
            agencies.Where(agency => deal.AgencyRelatedHotelDeals!.Select(related => related.AgencyId).Contains(agency.Id)).Select(agency => new HotelDealAgencyResponse(
                agency.Id,
                agency.Name
            )).ToArray()
        )).ToArray();

        return response;
    }
}