using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Users.UpdateUser;

public class UpdateUserCommandValidator : TravelAgencyAbstractValidator<UpdateUserCommand>
{
    private IUnitOfWork unitOfWork;

    public UpdateUserCommandValidator(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;


        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.UserId)
            .MustAsync((id, token) => unitOfWork.GetRepository<User>().ExistsAsync(x => x.Id == id))
            .WithMessage("User ID is not found");
    }
}
