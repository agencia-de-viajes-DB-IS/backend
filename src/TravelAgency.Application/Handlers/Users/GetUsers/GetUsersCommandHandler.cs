using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Users.GetUsers;

public class GetUsersCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUsersCommand, IEnumerable<UserResponse>>
{
    public async Task<IEnumerable<UserResponse>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
    {
        var userRepo = unitOfWork.GetRepository<Domain.Entities.User>();
        var response = (await userRepo.FindAllAsync())
            .Select(user => new UserResponse(
                user.FirstName,
                user.LastName,
                user.Email
        ));
        return response;
    }
}
