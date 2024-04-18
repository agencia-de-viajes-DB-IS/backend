using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Statistics.Queries.ExtendedWeekendExcursions;

public class ExtendedWeekendExcursionCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<ExtendedWeekendExcursionCommand, ExtendedWeekendExcursionResponse[]>
{

    public async Task<ExtendedWeekendExcursionResponse[]> Handle(ExtendedWeekendExcursionCommand request, CancellationToken cancellationToken)
    {
        var excursionRepo = _unitOfWork.GetRepository<Excursion>();

        var excursions = await excursionRepo.FindAllAsync(filters: [
            excursion => excursion.ArrivalDate.DayOfWeek == DayOfWeek.Friday || excursion.ArrivalDate.DayOfWeek == DayOfWeek.Saturday || excursion.ArrivalDate.DayOfWeek == DayOfWeek.Sunday
        ]);

        var response = excursions.Select(excursion => new ExtendedWeekendExcursionResponse(
            excursion.Location,
            excursion.ArrivalDate.TimeOfDay,
            (excursion is ExtendedExcursion extendedExcursion) ? (extendedExcursion.DepartureDate - extendedExcursion.ArrivalDate).Days : 0
        )).ToList();

        response.Sort((response1, response2) => response1.Location.CompareTo(response2.Location));

        return response.ToArray();
    }
}