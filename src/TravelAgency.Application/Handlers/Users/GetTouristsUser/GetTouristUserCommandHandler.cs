using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Users.GetTouristsUser;

// GENERATE A HANDLER

public class GetTouristUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUserTouristCommand, GetTouristDto[]>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<GetTouristDto[]> Handle(GetUserTouristCommand request, CancellationToken cancellationToken)
    {
        var userIncludes = new Expression<Func<User, object>>[]
        {
            user => user.Tourists!
        };

        var userFilter = new Expression<Func<User, bool>>[]
        {
            user => user.Id == request.UserId
        };

        var user = await unitOfWork.GetRepository<User>().FindAsync( userIncludes, userFilter);

        GetTouristDto[] tourists = user!.Tourists!.Where(t => t.Flag).Select(t => new GetTouristDto
        (
            user.Id,
            t.Id,
            t.CI,
            t.FirstName,
            t.LastName,
            t.Nationality
        )).ToArray();
        
        return tourists;
    }
}