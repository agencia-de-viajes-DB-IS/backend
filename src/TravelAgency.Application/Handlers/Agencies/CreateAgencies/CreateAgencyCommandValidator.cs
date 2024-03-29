using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Agencies.CreateAgencies;

public class CreateAgencyCommandValidator : TravelAgencyAbstractValidator<CreateAgencyCommand>
{
    public CreateAgencyCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required")
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters");
        RuleFor(x => x.FaxNumber)
            .NotEmpty().WithMessage("Fax Number is required");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");
    }
}