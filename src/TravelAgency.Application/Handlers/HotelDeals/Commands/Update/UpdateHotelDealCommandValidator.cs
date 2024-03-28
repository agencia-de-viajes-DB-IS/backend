using FluentValidation;
using TravelAgency.Application.Common;

namespace TravelAgency.Application.Handlers.HotelDeals.Commands.Update;

public class UpdateHotelDealCommandValidator : TravelAgencyAbstractValidator<UpdateHotelDealCommand>
{
    public UpdateHotelDealCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");  
    }
}