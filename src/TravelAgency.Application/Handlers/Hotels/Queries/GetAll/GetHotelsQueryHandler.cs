using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Hotels.Queries.GetAll; 

public class GetHotelsQueryHandler : IRequestHandler<GetHotelsQuery, IEnumerable<GetHotelsResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetHotelsQueryHandler(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<IEnumerable<GetHotelsResponse>> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
    {
        var hotelsRepo = unitOfWork.GetRepository<Hotel>();
        var hotelsIncludes = new Expression<Func<Hotel, object>>[]
        {
            Hotels => Hotels.Deals!,
        };
        var response = (await hotelsRepo.FindAllAsync(includes: hotelsIncludes))
            .Select(Hotels => new GetHotelsResponse(
                Hotels.Name,
                Hotels.Address,
                Hotels.Deals,
                Hotels.Category, 
                Hotels.Id
        ));
        return response;
    }
}