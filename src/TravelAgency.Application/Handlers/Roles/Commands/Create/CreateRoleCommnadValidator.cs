using FluentValidation;
using TravelAgency.Application.Common;

namespace TravelAgency.Application.Handlers.Roles.Commands.Create;

public class CreateRoleCommandValidator : TravelAgencyAbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");
    }
}