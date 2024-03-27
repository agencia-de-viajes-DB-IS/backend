using FluentValidation;
using TravelAgency.Application.Common;

namespace TravelAgency.Application.Handlers.Hotels.Commands.Update;

public class UpdateHotelCommandValidator : TravelAgencyAbstractValidator<UpdateHotelCommand>
{
    public UpdateHotelCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required"); 
    }
}