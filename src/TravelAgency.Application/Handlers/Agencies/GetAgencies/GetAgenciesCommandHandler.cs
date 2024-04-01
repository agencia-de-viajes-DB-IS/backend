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
        var agencyFilter = new Expression<Func<Agency, bool>>[]
        {
            agency => request.NameFilter == "" || agency.Name == request.NameFilter,
            agency => request.EmailFilter == "" || agency.Email == request.EmailFilter,
            agency => request.FaxNumberFilter == default || agency.FaxNumber == request.FaxNumberFilter,
            agency => request.AddressFilter == "" || agency.Address == request.AddressFilter
        };
        var agencyHotelDealIncludes = new Expression<Func<AgencyRelatedHotelDeal, object>>[]
        {
            agencyHotelDeal => agencyHotelDeal.HotelDeal.Hotel!
        };

        var agencies = await agencyRepo.FindAllAsync(includes: agencyIncludes, filters: agencyFilter);
        var response= agencies.Select(agency =>
        {
            var result = new GetAgencyResponse(
                agency.Id,
                agency.Name,
                agency.Address,
                agency.FaxNumber,
                agency.Email
            );
            return result;
        });
        // Wait for all tasks to complete and then convert the results to an array
        return response.ToArray();
    }
}