using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Airlines.GetAirlines;
using TravelAgency.Application.Handlers.Statistics.Queries.ReservationStats;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Handlers.Users.GetUsers;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.ExcursionReservations.GetExcursionRerservation;

public class GetExcursionReservationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetExcursionReservationCommand, GetExcursionRerservationResponse[]>
{
    public async Task<GetExcursionRerservationResponse[]> Handle(GetExcursionReservationCommand request, CancellationToken cancellationToken)
    {
        var excReservationRepo = unitOfWork.GetRepository<ExcursionReservation>();

        var includes = new Expression<Func<ExcursionReservation, object>>[] {
            excR => excR.User,
            excR => excR.Excursion,
            excR => excR.Airline,
            excR => excR.Tourists
        };

        var filters = new Expression<Func<ExcursionReservation, bool>>[] {
            excR => request.AirlineIdFilter == default || excR.AirlineId == request.AirlineIdFilter,
            excR => request.UserIdFilter == default || excR.UserId == request.UserIdFilter,
            excR => request.PriceFilter == default || excR.Price >= request.PriceFilter,
            excR => request.ExcursionIdFilter == default || excR.ExcursionId == request.ExcursionIdFilter,
            excR => request.ReservationDate == default || excR.ReservationDate >= request.ReservationDate
        };

        var response = (await excReservationRepo.FindAllAsync(includes: includes, filters: filters))
            .Select(excReservation => new GetExcursionRerservationResponse(
                excReservation.Id,
                new UserResponse(
                    excReservation.User.Id,
                    excReservation.User.FirstName,
                    excReservation.User.LastName,
                    excReservation.User.Email,
                    excReservation.UserId
                ),
                new AirlineResponse(
                    excReservation.Airline.Id,
                    excReservation.Airline.Name
                ),
                excReservation.ReservationDate,
                new ExcursionReservationResponse(
                    excReservation.Excursion.Id,
                    excReservation.Excursion.Name,
                    excReservation.Excursion.Description
                ),
                excReservation.Price,
                excReservation.Tourists.Select(tourist => new TouristResponse(
                    excReservation.UserId,
                    tourist.Id,
                    tourist.CI,
                    tourist.FirstName,
                    tourist.LastName,
                    tourist.Nationality
                )).ToArray()
            )).ToArray();
        return response;
    }
}
