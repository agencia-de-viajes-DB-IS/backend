using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Application.Responses;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Agencies.GetAgencies;

public class GetAgenciesCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAgenciesCommand, IEnumerable<AgencyResponse>>
{
    public async Task<IEnumerable<AgencyResponse>> Handle(GetAgenciesCommand request, CancellationToken cancellationToken)
    {
        var agencyRepo = _unitOfWork.GetRepository<Agency>();
        var agencyHotelDealsRepo = _unitOfWork.GetRepository<AgencyRelatedHotelDeal>();
        
        var agencyIncludes = new Expression<Func<Agency, object>>[]
        {
            agency => agency.Excursions!,
            agency => agency.AgencyRelatedHotelDeals!
        };

        Dictionary<Guid, List<AgencyRelatedHotelDeal>> d = new();
        
        var hotelIncludes = new Expression<Func<AgencyRelatedHotelDeal, object>>[]
        {
            agency => agency.HotelDeal.Hotel,
        };

        var response2 = (await agencyHotelDealsRepo.FindAllAsync(hotelIncludes));
        foreach (var xAgencyRelatedHotelDeal in response2)
        {
            if (!d.ContainsKey(xAgencyRelatedHotelDeal.AgencyId))
            {
                d[xAgencyRelatedHotelDeal.AgencyId] = new();
            }
            d[xAgencyRelatedHotelDeal.AgencyId].Add(xAgencyRelatedHotelDeal);
        }
        var response = (await agencyRepo.FindAllAsync(includes: agencyIncludes))
            .Select(agency => new AgencyResponse(
                agency.Name,
                agency.Address,
                agency.FaxNumber,
                agency.Email,
                agency.Excursions!.Select(x => new AgencyExcursionResponse(
                    x.Location, 
                    x.Price, 
                    x.ArrivalDate)),
                d[agency.Id].Select(
                    x => new AgencyHotelDealResponse(
                        x.HotelDeal.Hotel.Name,
                        x.HotelDeal.Description,
                        x.HotelDeal.Price,
                        x.HotelDeal.ArrivalDate,
                        x.HotelDeal.DepartureDate
                        ))));
        return response;
    }
}