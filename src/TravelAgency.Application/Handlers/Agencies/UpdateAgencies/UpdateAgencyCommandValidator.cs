using FluentValidation;
using TravelAgency.Application.Common;
namespace TravelAgency.Application.Handlers.Agencies.UpdateAgencies;

public class UpdateAgencyCommandValidator : TravelAgencyAbstractValidator<UpdateAgencyCommand>
{
    public UpdateAgencyCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");
    }
}