using FluentValidation;
using TravelAgency.Application.Common;

namespace TravelAgency.Application.Handlers.HotelDeals.Commands.Delete;

public class DeleteHotelDealCommandValidator : TravelAgencyAbstractValidator<DeleteHotelDealCommand>
{
    public DeleteHotelDealCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required"); 
    }
}