namespace TravelAgency.Application.Responses;

public record HotelsDealsResponse(
    Guid Id,
    string Description,
    decimal Price,
    DateTime ArrivalDate,
    DateTime DepartureDate
);