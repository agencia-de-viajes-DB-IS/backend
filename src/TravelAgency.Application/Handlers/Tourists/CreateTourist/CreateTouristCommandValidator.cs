using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Tourists.CreateTourist;

public class CreateTouristCommandValidator : TravelAgencyAbstractValidator<CreateTouristCommand>
{
    public CreateTouristCommandValidator(IUnitOfWork unitOfWork)
    {
        // Validation process
        RuleFor(x => x.CI)
            .NotEmpty().WithMessage("CI is required")
            .MaximumLength(30).WithMessage("CI must not exceed 30 characters");
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName is required")
            .MaximumLength(200).WithMessage("FirstName must not exceed 200 characters");
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName is required")
            .MaximumLength(200).WithMessage("LastName must not exceed 200 characters");
        RuleFor(x => x.Nationality)
            .NotEmpty().WithMessage("Nationality is required")
            .MaximumLength(200).WithMessage("Nationality must not exceed 200 characters");
        RuleFor(x => x)
            .MustAsync(async (mm, token) => {  
                var flag = await unitOfWork.GetRepository<Tourist>().FindAllAsync(filters: 
                [x => x.CI == mm.CI,
                x => x.UserId == mm.UserId, 
                x => x.Flag]
                ); 
                return !flag.Any(); })
            .WithMessage("Tourist is there with that CI");
    }
}