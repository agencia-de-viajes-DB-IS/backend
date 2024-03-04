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
        var agencyRelatedHotelDeal = _unitOfWork.GetRepository<AgencyRelatedHotelDeal>();       

        var agencyIncludes = new Expression<Func<Agency, object>>[]
        {
            agency => agency.Excursions!,
        };

        var agencyHotelDealIncludes = new Expression<Func<AgencyRelatedHotelDeal, object>>[]
        {
            agencyHotelDeal => agencyHotelDeal.HotelDeal.Hotel!
        };
        
        var response = (await agencyRepo.FindAllAsync(includes: agencyIncludes))
            .Select(async agency => (new AgencyResponse(
                agency.Name,
                agency.Address,
                agency.FaxNumber,
                agency.Email,
                agency.Excursions!.Select(x => new AgencyExcursionResponse(
                    x.Location,
                    x.Price,
                    x.ArrivalDate)),
                (await agencyRelatedHotelDeal.FindAllAsync(agencyHotelDealIncludes, filters: new Expression<Func<AgencyRelatedHotelDeal, bool>>[]{ x => x.AgencyId == agency.Id}))
                    .Select(
                    x => new AgencyHotelDealResponse(
                        x.HotelDeal.Hotel.Name, 
                        x.HotelDeal.Description, 
                        x.HotelDeal.Price, 
                        x.HotelDeal.ArrivalDate, 
                        x.HotelDeal.DepartureDate))
                )));
        var results = await Task.WhenAll(response);
        return results;
    }
}