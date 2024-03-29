using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Roles.Queries.GetAll; 

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IEnumerable<GetRolesResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetRolesQueryHandler(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<IEnumerable<GetRolesResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var RolesRepo = unitOfWork.GetRepository<Role>();
        var response = (await RolesRepo.FindAllAsync())
            .Select(Roles => new GetRolesResponse(
                Roles.Name,
                Roles.Permissions
        ));
        return response;
    }
}