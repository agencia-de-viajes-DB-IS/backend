using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Users.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IUnitOfWork unitOfWork;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserCommandValidator(unitOfWork);
        await validator.ValidateAsync(request, cancellationToken);
        var userRepo = unitOfWork.GetRepository<User>();
        var user = await userRepo.FindAsync(filters: [x => x.Id == request.UserId]);
        user!.Email = request.Email;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        await userRepo.UpdateAsync(user);
        await unitOfWork.SaveAsync();
        return new UpdateUserResponse();
    }
}
