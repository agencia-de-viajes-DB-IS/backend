using FluentValidation;

namespace TravelAgency.Application.Handlers.HotelDeals.Commands.Create;

public class CreateHotelDealCommandValidator : AbstractValidator<CreateHotelDealCommand>
{
    public CreateHotelDealCommandValidator()
    {
        RuleFor(x => x.DepartureDate)
            .NotEmpty().WithMessage("DepartureDate is required"); 
        RuleFor(x => x.ArrivalDate)
            .NotEmpty().WithMessage("ArrivalDate is required"); 
            
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Category is required")
            .Must(x => x > 0).WithMessage("Invalid price"); 
    }
}