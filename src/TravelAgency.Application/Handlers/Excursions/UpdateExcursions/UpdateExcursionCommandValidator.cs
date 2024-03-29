using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Handlers.Agencies.UpdateAgencies;
using TravelAgency.Application.Handlers.Excursions.CreateExcursions;

namespace TravelAgency.Application.Handlers.Excursions.UpdateExcursions;

public class UpdateExcursionCommandValidator : TravelAgencyAbstractValidator<UpdateExcursionCommand>
{
    public UpdateExcursionCommandValidator()
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters");
        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required")
            .MaximumLength(200).WithMessage("Location must not exceed 200 characters");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be a positive number");

        RuleFor(x => x.ArrivalDate)
            .Must(date => date >= DateTime.Now).WithMessage("Arrival date must not be in the past");
    }
}