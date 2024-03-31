using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Excursions.GetExcursions;

public class GetExcursionsCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetExcursionsCommand, GetExcursionResponse[]>
{
    public async Task<GetExcursionResponse[]> Handle(GetExcursionsCommand request, CancellationToken cancellationToken)
    {
        var excursionRepo = unitOfWork.GetRepository<Excursion>();

        var excursionIncludes = new List<Expression<Func<Excursion, object>>>
        {
            excursion => excursion.Agency
        };

        var excursionFilters = new List<Expression<Func<Excursion, bool>>>
        {
            excursion => request.PriceFilter == default || excursion.Price >= request.PriceFilter,
            excursion => request.ArrivalDateFilter == default || excursion.ArrivalDate >= request.ArrivalDateFilter,
            excursion => request.AgencyIdFilter == default || excursion.AgencyId == request.AgencyIdFilter,
            excursion => request.NameFilter == "" || excursion.Name == request.NameFilter,
            excursion => request.LocationFilter == "" || excursion.Location == request.LocationFilter,
        };

        if (!request.IncludeExtended)
        {
            var extendedRepo = unitOfWork.GetRepository<ExtendedExcursion>();
            IEnumerable<Guid> extendedIDs = (await extendedRepo.FindAllAsync()).Select(x => x.Id);
            excursionFilters.Add(excursion => !extendedIDs.Contains(excursion.Id));           
        }
        var response = (await excursionRepo.FindAllAsync(excursionIncludes, excursionFilters))
                                .Select(excursion => new GetExcursionResponse(
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
                                            excursion.Agency.Email)
                                    ));
        return response.ToArray();
    }
}