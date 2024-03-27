using FluentValidation;
using TravelAgency.Application.Common;

namespace TravelAgency.Application.Handlers.Hotels.Commands.Delete;

public class DeleteHotelCommandValidator : TravelAgencyAbstractValidator<DeleteHotelCommand>
{
    public DeleteHotelCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required"); 
    }
}