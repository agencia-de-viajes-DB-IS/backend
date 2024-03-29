using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Users.AddTouristUser;

public class AddUserTouristCommandValidator : TravelAgencyAbstractValidator<AddUserTouristCommand>
{
    public AddUserTouristCommandValidator(IUnitOfWork unitOfWork)
    {
        // check if user exist in database.
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required")
            .MustAsync(async (id, token) => await unitOfWork.GetRepository<User>().ExistsAsync(a => a.Id == id))
            .WithMessage("User with provided id doesn't exist");
        // check if tourist exist in database.
                RuleFor(x => x.TouristId)
            .NotEmpty().WithMessage("Tourist is required")
            .MustAsync(async (id, token) => await unitOfWork.GetRepository<Tourist>().ExistsAsync(a => a.Id == id))
            .WithMessage("Tourist with provided id doesn't exist");
    }
}