using System.Data;
using System.Linq.Expressions;
using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;
namespace TravelAgency.Application.Handlers.Packages.CreatePackage;

public class CreatePackageCommandValidator : TravelAgencyAbstractValidator<CreatePackageCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreatePackageCommandValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        // Validation process
        RuleFor(x => x.ExtendedExcursionIds)
            .Must(z => z.Any())
            .WithMessage("At least one extended excursion");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters");
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
        RuleFor(x => x)
            .MustAsync(async (x, _) => await ValidateExcursions(x.ExtendedExcursionIds, x.ArrivalDate, x.DepartureDate))
            .WithMessage(@"Excursions: Must belong to the same agency, Their arrival and departure dates must be included in those of the package, A package must contain at least one extended-excursion");
    }

    private async Task<bool> ValidateExcursions(IEnumerable<Guid> extendedExcursionIds, DateTime arrivalDate, DateTime departureDate)
    {
        var excursionRepo = _unitOfWork.GetRepository<ExtendedExcursion>();

        var excursionFilter = new Expression<Func<ExtendedExcursion, bool>>[]
        {
            excursion => extendedExcursionIds.Contains(excursion.Id)
        };

        var excursions = await excursionRepo.FindAllAsync(filters: excursionFilter);

        var firstExcursion = excursions.FirstOrDefault();
        var agencyId = firstExcursion is null ? Guid.NewGuid() : firstExcursion.AgencyId;

        return excursions.All(excursion => excursion.ArrivalDate >= arrivalDate && excursion.DepartureDate <= departureDate) && excursions.All(excursion => excursion.AgencyId == agencyId) && excursions.Count() > 0;
    }
}