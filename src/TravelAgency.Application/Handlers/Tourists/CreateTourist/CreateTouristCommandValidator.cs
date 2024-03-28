using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;

namespace TravelAgency.Application.Handlers.Tourists.CreateTourist;

public class CreateTouristCommandValidator : TravelAgencyAbstractValidator<CreateTouristCommand>
{
    public CreateTouristCommandValidator()
    {
        // Validation process
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .MaximumLength(30).WithMessage("Id must not exceed 30 characters");
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName is required")
            .MaximumLength(200).WithMessage("FirstName must not exceed 200 characters");
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName is required")
            .MaximumLength(200).WithMessage("LastName must not exceed 200 characters");
        RuleFor(x => x.Nationality)
            .NotEmpty().WithMessage("Nationality is required")
            .MaximumLength(200).WithMessage("Nationality must not exceed 200 characters");
    }
}