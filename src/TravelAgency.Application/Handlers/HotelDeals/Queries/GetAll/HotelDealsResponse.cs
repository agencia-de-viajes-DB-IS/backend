namespace TravelAgency.Application.Handlers.HotelDeals.Queries.GetAll;
public record HotelsDealsResponse(
    Guid Id,
    Guid HotelId,
    string Name,
    string Description,
    decimal Price,
    int Capacity,
    DateTime ArrivalDate,
    DateTime DepartureDate,
    Domain.Entities.AgencyRelatedHotelDeal[]? agencyRelatedHotelDeals
);