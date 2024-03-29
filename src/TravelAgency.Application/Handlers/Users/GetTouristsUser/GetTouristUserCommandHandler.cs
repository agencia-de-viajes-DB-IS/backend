using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;
namespace TravelAgency.Application.Handlers.Users.GetTourist;

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

        var user = await unitOfWork.GetRepository<User>().FindAsync( includes: new List<Expression<Func<User, object>>>(userIncludes), filters: new List<Expression<Func<User, bool>>>(userFilter));

        GetTouristDto[] tourists = user!.Tourists!.Select(t => new GetTouristDto
        (
            t.Id,
            t.FirstName,
            t.LastName,
            t.Nationality
        )).ToArray();
        
        return tourists;
    }
}