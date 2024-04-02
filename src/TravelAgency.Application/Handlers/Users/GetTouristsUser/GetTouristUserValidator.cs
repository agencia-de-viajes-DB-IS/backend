using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Handlers.Users.GetTouristsUser;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Users.GetTouristsUser
{
    public class GetTouristUserValidator : TravelAgencyAbstractValidator<GetUserTouristCommand>
    {
        public GetTouristUserValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserId)
           .NotEmpty().WithMessage("UserId is required")
           .MustAsync(async (id, token) => await unitOfWork.GetRepository<User>().ExistsAsync(a => a.Id == id));
        }
    }
}