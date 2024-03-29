using FluentValidation;
using TravelAgency.Application.Common;

namespace TravelAgency.Application.Handlers.Roles.Commands.Update;

public class UpdateRoleCommandValidator : TravelAgencyAbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required"); 
    }
}