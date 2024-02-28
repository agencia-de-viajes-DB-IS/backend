using System.Linq.Expressions;
using MediatR;
using TravelAgency.Api.Responses;
using TravelAgency.Application.Interfaces.Persistence;

namespace TravelAgency.Application.Handlers.User.GetUsers;

public class GetUsersCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetUsersCommand, IEnumerable<UserResponse>>
{
    public async Task<IEnumerable<UserResponse>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
    {
        var userRepo = _unitOfWork.GetRepository<Domain.Entities.User>();

        var response = (await userRepo.FindAllAsync())
            .Select(user => new UserResponse(
                user.FirstName,
                user.LastName,
                user.Email
        ));

        return response;
    }
}
