using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Users.AddTouristUser;

public class AddUserTouristCommandHnalder : IRequestHandler<AddUserTouristCommand, AddTouristResponse>
{
    public AddUserTouristCommandHnalder(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; }

    public async Task<AddTouristResponse> Handle(AddUserTouristCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddUserTouristCommandValidator(UnitOfWork);
        await validator.ValidateAsync(request, cancellationToken);
        var user = await UnitOfWork.GetRepository<User>().FindAsync(includes: [
            x => x.Tourists!
        ], filters: [
            x => x.Id == request.UserId
        ]);

        if (!user!.Tourists!.Any(x => x.Id == request.TouristId)) 
        {
            var tourist = await UnitOfWork.GetRepository<Tourist>().FindAsync(filters: [
            x => x.Id == request.TouristId]);
            user!.Tourists!.Add(tourist!);
            await UnitOfWork.GetRepository<User>().UpdateAsync(user);
            await UnitOfWork.SaveAsync(); 
        }
        return new AddTouristResponse();
    }
}