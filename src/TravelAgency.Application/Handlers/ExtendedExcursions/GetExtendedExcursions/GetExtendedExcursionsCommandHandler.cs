using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using MediatR;
using TravelAgency.Application.Handlers.Excursions.GetExcursions;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.ExtendedExcursions.GetExtendedExcursions;

public class GetExtendedExcursionsCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetExtendedExcursionCommand, GetExtendedExcursionResponse[]>
{
    public IUnitOfWork UnitOfWork { get; set; } = unitOfWork;
    public async Task<GetExtendedExcursionResponse[]> Handle(GetExtendedExcursionCommand request, CancellationToken cancellationToken)
    {
        var extendedExcursionRepo = UnitOfWork.GetRepository<ExtendedExcursion>();
        var excursionIncludes = new List<Expression<Func<ExtendedExcursion, object>>>
        {
            excursion => excursion.Agency,
            excursion => excursion.HotelDeals
        };
        var excursionFilters = new List<Expression<Func<ExtendedExcursion, bool>>>
        {
            excursion => request.PriceFilter == default || excursion.Price >= request.PriceFilter,
            excursion => request.ArrivalDateFilter == default || excursion.ArrivalDate >= request.ArrivalDateFilter,
            excursion => request.AgencyIdFilter == default || excursion.AgencyId == request.AgencyIdFilter,
            excursion => request.NameFilter == "" || excursion.Name == request.NameFilter,
            excursion => request.LocationFilter == "" || excursion.Location == request.LocationFilter,
            excursion => request.DepartureDateFilter == default || excursion.DepartureDate <= request.DepartureDateFilter,
            excursion => request.HoteDealIdFilter == default || excursion.HotelDeals.Select(x => x.Id).Contains(request.HoteDealIdFilter)
        };
        var resp = await extendedExcursionRepo.FindAllAsync(excursionIncludes, excursionFilters);
        return resp.Select(excursion => new GetExtendedExcursionResponse(
                                        excursion.Id,
                                        excursion.Name,
                                        excursion.Name,
                                        excursion.Location,
                                        excursion.Price,
                                        excursion.ArrivalDate,
                                        new ExcursionAgencyResponse(
                                            excursion.Agency.Name,
                                            excursion.Agency.Address,
                                            excursion.Agency.FaxNumber,
                                            excursion.Agency.Email),
                                        excursion.DepartureDate,
                                        excursion.HotelDeals.Select(x => new GetExtendedExcursionHotelDealResponse(x.Name, x.Id)).ToArray()
                                    )).ToArray();
    }
}
