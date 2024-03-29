using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Agencies.GetAgencies;

public class GetAgenciesCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAgenciesCommand, GetAgencyResponse[]>
{
    public async Task<GetAgencyResponse[]> Handle(GetAgenciesCommand request, CancellationToken cancellationToken)
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
            .Select(async agency => (
                new GetAgencyResponse(
                new GetAgencyDto(
                    agency.Id,
                    agency.Name,
                    agency.Address,
                    agency.FaxNumber,
                    agency.Email,
                    agency.Excursions!.Select(x => new AgencyExcursionResponse(
                        x.Location,
                        x.Price,
                        x.ArrivalDate)).ToArray(),
                    (await agencyRelatedHotelDeal.FindAllAsync(agencyHotelDealIncludes, filters: [x => x.AgencyId == agency.Id]))
                    .Select(
                        x => new AgencyHotelDealResponse(
                            x.HotelDeal.Hotel.Name,
                            x.HotelDeal.Description,
                            x.HotelDeal.Price,
                            x.HotelDeal.ArrivalDate,
                            x.HotelDeal.DepartureDate))))));
                ;
        var results = await Task.WhenAll(response);
        foreach (var item in results)
        {
            item.GetAgencyDto.HotelDeals = item.GetAgencyDto.HotelDeals.ToArray();
        }
        return results;
    }
}