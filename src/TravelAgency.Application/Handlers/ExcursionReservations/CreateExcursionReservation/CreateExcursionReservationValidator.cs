using System.Linq.Expressions;
using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.ExcursionReservations.CreateExcursionReservation;

public class CreateExcursionReservationValidator : TravelAgencyAbstractValidator<CreateExcursionReservationCommand>
{

    public CreateExcursionReservationValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.AirlineId)
            .NotEmpty().WithMessage("AirlineId is required")
            .MustAsync(async (id, token) => await unitOfWork.GetRepository<Airline>().ExistsAsync(a => a.Id == id))
            .WithMessage("Airline with provided id doesn't exist");
        //same with user
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required")
            .MustAsync(async (id, token) => await unitOfWork.GetRepository<User>().ExistsAsync(u => u.Id == id))
            .WithMessage("User with provided id doesn't exist");
        // same with excursion
        RuleFor(x => x.ExcursionId)
            .NotEmpty().WithMessage("ExcursionId is required")
            .MustAsync(async (id, token) => await unitOfWork.GetRepository<Excursion>().ExistsAsync(e => e.Id == id))
            .WithMessage("Excursion with provided id doesn't exist");

        // check date of excursion with respect date of request.
        
        RuleFor(x => x.ReservationDate)
            .NotEmpty().WithMessage("ReservationDate is required")
            .MustAsync(async (x, requestDate, token) =>
            {
                var excursion = await unitOfWork.GetRepository<Excursion>().FindAsync(filters:
                [
                    e => e.Id == x.ExcursionId
                ]);
                var excursionDate = excursion!.ArrivalDate;
                return requestDate.Date <= excursionDate;
            })
            .WithMessage("Reservation date must be before or equal to excursion date");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}