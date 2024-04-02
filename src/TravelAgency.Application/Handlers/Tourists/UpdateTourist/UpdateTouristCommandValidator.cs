using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Tourists.UpdateTourist;


public class UpdateTouristCommandValidator : TravelAgencyAbstractValidator<UpdateTouristCommand>
{
    private IUnitOfWork unitOfWork;

    public UpdateTouristCommandValidator(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        // Validation process
        RuleFor(x => x.CI)
            .NotEmpty().WithMessage("CI is required")
            .MaximumLength(30).WithMessage("CI must not exceed 30 characters");
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName is required")
            .MaximumLength(200).WithMessage("FirstName must not exceed 200 characters");
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName is required")
            .MaximumLength(200).WithMessage("LastName must not exceed 200 characters");
        RuleFor(x => x.Nationality)
            .NotEmpty().WithMessage("Nationality is required")
            .MaximumLength(200).WithMessage("Nationality must not exceed 200 characters");
        RuleFor(x => x)
            .MustAsync(async (mm, token) => {
                return await unitOfWork.GetRepository<Tourist>().ExistsAsync(x => x.Id == mm.TouristId && x.Flag);
            })
            .WithMessage("No tourist to EDIT");
    }
}