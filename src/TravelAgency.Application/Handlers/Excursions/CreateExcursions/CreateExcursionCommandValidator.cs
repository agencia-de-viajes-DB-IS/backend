using FluentValidation;
using TravelAgency.Application.Handlers.Agencies.CreateAgencies;

namespace TravelAgency.Application.Handlers.Excursions.CreateExcursions;

public class CreateExcursionCommandValidator : AbstractValidator<CreateExcursionCommand>
{ 
    public CreateExcursionCommandValidator()
    {
            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required")
                .MaximumLength(200).WithMessage("Location must not exceed 200 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be a positive number");

            RuleFor(x => x.ArrivalDate)
                .Must(date => date >= DateTime.Now).WithMessage("Arrival date must not be in the past");

            RuleFor(x => x.AgencyId)
                .NotEmpty().WithMessage("Excursion ID is required");
    }
}