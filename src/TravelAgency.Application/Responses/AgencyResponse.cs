using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Responses;

public record AgencyResponse
(
    string Name,
    string Address,
    int FaxNumber,
    string Email,
    IEnumerable<AgencyExcursionResponse>? Excursions,
    IEnumerable<AgencyHotelDealResponse>? HotelDeals
);

public record AgencyHotelDealResponse(
    string Name,
    string Description,
    decimal Price,
    DateTime ArrivalDate, 
    DateTime DepartureDate
    );

public record AgencyExcursionResponse(
    string Location,
    decimal Price,
    DateTime ArrivalDate);