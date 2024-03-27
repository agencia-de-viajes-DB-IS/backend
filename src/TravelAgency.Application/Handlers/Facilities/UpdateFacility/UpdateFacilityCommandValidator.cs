using FluentValidation;
using TravelAgency.Application.Common;

namespace TravelAgency.Application.Handlers.Facilities.UpdateFacility;

public class UpdateFacilityCommandValidator : TravelAgencyAbstractValidator<UpdateFacilityCommand>
{
    public UpdateFacilityCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters");
    }
}