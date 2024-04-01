using MediatR;

namespace TravelAgency.Application.Handlers.HotelDealReservations.Queries.GetAll
{
    public record GetAllHotelDealReservationsQuery(
        Guid UserIdFilter,
        Guid HotelDealIdFilter,
        Guid AirlineIdFilter,
        DateTime ReservationDateFilter
    ) : IRequest<GetAllHotelDealReservationsResponse[]>;
}