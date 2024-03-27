using FluentValidation;
using TravelAgency.Application.Common;

namespace TravelAgency.Application.Handlers.Facilities.CreateFacility;

public class CreateFacilityCommandValidator : TravelAgencyAbstractValidator<CreateFacilityCommand>
{
    public CreateFacilityCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters");
    }
}