using FluentValidation;
using TravelAgency.Application.Common;

namespace TravelAgency.Application.Handlers.ExcursionReservations.CreateExcursionReservation;

public class CreateExcursionReservationValidator : TravelAgencyAbstractValidator<CreateExcursionReservationCommand>
{
    public CreateExcursionReservationValidator()
    {
        // price must be > 0
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}