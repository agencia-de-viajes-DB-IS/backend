using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.ExtendedExcursions.UpdateExtendedExcursions;

public class UpdateExtendedExcursionValidator : TravelAgencyAbstractValidator<UpdateExtendedExcursionCommand>
{
    public static bool AreDatesInChronologicalOrder(List<DateTime> dates)
    {
        for (int i = 0; i < dates.Count - 1; i++)
        {
            if (dates[i] > dates[i + 1])
            {
                return false;
            }
        }
        return true;
    }
    public UpdateExtendedExcursionValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required")
            .MaximumLength(200).WithMessage("Location must not exceed 200 characters");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be a positive number");

        RuleForEach(x => x.HotelDealsIDs)
            .MustAsync((id, token) => unitOfWork.GetRepository<HotelDeal>().ExistsAsync(x => x.Id == id))
            .WithMessage("Hotel Deal not found");


        var seed = DateTime.Now;

        RuleFor(x => x.ArrivalDate)
            .Must(y =>
            {
                seed = y;
                return y >= DateTime.Now;
            })
            .WithMessage("Arrival Date is in the Past");

        RuleForEach(x => x.HotelDealsIDs)
            .MustAsync(async (id, token) =>
            {
                var hd = await unitOfWork.GetRepository<HotelDeal>().FindAsync(filters: [hd => hd.Id == id]);
                if (hd!.ArrivalDate < seed)
                {
                    return false;
                }
                else
                {
                    seed = hd!.ArrivalDate;
                }

                if (hd!.DepartureDate < seed)
                {
                    return false;
                }
                else
                {
                    seed = hd!.DepartureDate;
                }
                return true;
            })
            .WithMessage("Dates are not in chronological order");

        RuleFor(x => x.DepartureDate)
            .Must(y =>
            {
                return y >= seed;
            })
            .WithMessage("Departure data is before than end of the excursion");
    }
}