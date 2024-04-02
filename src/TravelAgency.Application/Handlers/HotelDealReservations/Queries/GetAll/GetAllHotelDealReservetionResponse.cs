using TravelAgency.Application.Handlers.Airlines.GetAirlines;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Handlers.Users.GetUsers;

namespace TravelAgency.Application.Handlers.HotelDealReservations.Queries.GetAll
{
    public record GetAllHotelDealReservationsResponse(
        Guid Id,
        UserResponse User,
        HotelDealResponseOnReservation HotelDeal,
        AirlineResponse Airline,
        DateTime ReservationDate,
        TouristResponse[] Tourists
    );

    public record HotelDealResponseOnReservation(
        decimal Price
    );
}