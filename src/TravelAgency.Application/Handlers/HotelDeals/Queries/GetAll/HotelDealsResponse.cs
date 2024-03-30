namespace TravelAgency.Application.Handlers.HotelsDeals.Queries.GetAll;
public record HotelsDealsResponse(
    Guid Id,
    Guid HotelId,
    string Name,
    string Description,
    decimal Price,
    DateTime ArrivalDate,
    DateTime DepartureDate
);