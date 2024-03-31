using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Handlers.Agencies.CreateAgencies;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Excursions.CreateExcursions;

public class CreateExcursionCommandValidator : TravelAgencyAbstractValidator<CreateExcursionCommand>
{ 
    public CreateExcursionCommandValidator(IUnitOfWork unitOfWork)
    {
            // rule for name
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

            RuleFor(x => x.AgencyId)
                .NotEmpty().WithMessage("Excursion ID is required");

        RuleFor(x => x.AgencyId)
            .MustAsync((id, token) => unitOfWork.GetRepository<Agency>().ExistsAsync(x => x.Id == id))
            .WithMessage("Agency not found");
    }
}