using FluentValidation;
using TravelAgency.Application.Interfaces.Persistence;

namespace TravelAgency.Application.Handlers.Packages.UpdatePackage;

public class UpdatePackageCommandValidator : AbstractValidator<UpdatePackageCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdatePackageCommandValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        // Validation process
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters");
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
}