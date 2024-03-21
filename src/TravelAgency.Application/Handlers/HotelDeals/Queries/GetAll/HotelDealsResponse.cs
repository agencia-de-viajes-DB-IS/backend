namespace TravelAgency.Application.Handlers.HotelsDeals.Queries.GetAll;
public record HotelsDealsResponse(
    Guid Id,
    string Description,
    decimal Price,
    DateTime ArrivalDate,
    DateTime DepartureDate
);