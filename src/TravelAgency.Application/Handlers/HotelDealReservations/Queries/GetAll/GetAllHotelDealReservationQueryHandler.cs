using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Airlines.GetAirlines;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Handlers.Users.GetUsers;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.HotelDealReservations.Queries.GetAll
{
    public class GetAllHotelDealReservationsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllHotelDealReservationsQuery, GetAllHotelDealReservationsResponse[]>
    {
        public async Task<GetAllHotelDealReservationsResponse[]> Handle(GetAllHotelDealReservationsQuery request, CancellationToken cancellationToken)
        {
            var HotelDealReservationRepo = _unitOfWork.GetRepository<HotelDealReservation>();

            var HotelDealReservationFilters = new Expression<Func<HotelDealReservation, bool>>[]
            {
            HotelDealReservation => request.UserIdFilter == default || HotelDealReservation.UserId == request.UserIdFilter,
            HotelDealReservation => request.AirlineIdFilter == default || HotelDealReservation.AirlineId == request.AirlineIdFilter,
            HotelDealReservation => request.ReservationDateFilter == default || HotelDealReservation.ReservationDate == request.ReservationDateFilter,
            };

            var HotelDealReservationIncludes = new Expression<Func<HotelDealReservation, object>>[]
            {
            HotelDealReservation => HotelDealReservation.User,
            HotelDealReservation => HotelDealReservation.Airline,
            HotelDealReservation => HotelDealReservation.Tourists,
            };

            var response = (await HotelDealReservationRepo.FindAllAsync(includes: HotelDealReservationIncludes, filters: HotelDealReservationFilters))
                .Select(HotelDealReservation => new GetAllHotelDealReservationsResponse(
                    HotelDealReservation.Id,
                    new UserResponse(
                        HotelDealReservation.User.Id,
                        HotelDealReservation.User.FirstName,
                        HotelDealReservation.User.LastName,
                        HotelDealReservation.User.Email,
                        HotelDealReservation.UserId
                    ),
                    new HotelDealResponseOnReservation(
                        HotelDealReservation.Price
                    ),
                    new AirlineResponse(
                        HotelDealReservation.Airline.Id,
                        HotelDealReservation.Airline.Name
                    ),
                    HotelDealReservation.ReservationDate,
                    HotelDealReservation.Tourists.Select(tourist => new TouristResponse(
                        tourist.Id,
                        tourist.FirstName,
                        tourist.LastName,
                        tourist.Nationality
                    )).ToArray()
                )).ToArray();
            return response;
        }
    }
}