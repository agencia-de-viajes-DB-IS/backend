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
        var excursionIncludes = new Expression<Func<Excursion, object>>[]
        {
            excursion => excursion.Agency
        };
        
        var response = (await excursionRepo.FindAllAsync(excursionIncludes))
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