namespace TravelAgency.Application.Handlers.HotelDealReservations.Commands.Create
{
    public record CreateHotelDealReservationResponse(
        Guid Id, 
        string PaymentUrl
    );
}