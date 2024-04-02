using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Users.DeleteUser;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userRepo = unitOfWork.GetRepository<User>();
        var user = await userRepo.FindAsync(filters: [x => x.Id == request.UserId]);
        if(user != null)
        {
            await userRepo.DeleteAsync(request.UserId); 
        }
        await unitOfWork.SaveAsync();
        var resp = new DeleteUserResponse
        {
            Success = user != null
        };
        return resp;
    }
}
