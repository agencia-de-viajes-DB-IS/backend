using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Application.Responses;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Excursions.GetExcursions;

public class GetExcursionsCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetExcursionsCommand, IEnumerable<ExcursionResponse>>
{
    public async Task<IEnumerable<ExcursionResponse>> Handle(GetExcursionsCommand request, CancellationToken cancellationToken)
    {
        var excursionRepo = _unitOfWork.GetRepository<Excursion>();
        var excursionIncludes = new Expression<Func<Excursion, object>>[]
        {
            excursion => excursion.Agency
        };
        
        var response = (await excursionRepo.FindAllAsync(excursionIncludes))
            .Select(excursion => new ExcursionResponse(
                excursion.Location,
                excursion.Price,
                excursion.ArrivalDate,
                new ExcursionAgencyResponse(
                    excursion.Agency.Name,
                    excursion.Agency.Address,
                    excursion.Agency.FaxNumber,
                    excursion.Agency.Email)
            ));
        return response;
    }
}