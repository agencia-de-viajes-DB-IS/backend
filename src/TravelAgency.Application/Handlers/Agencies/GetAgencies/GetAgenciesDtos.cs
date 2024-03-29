namespace TravelAgency.Application.Handlers.Agencies.GetAgencies;

public record GetAgencyDto
(
    Guid Id,
    string Name,
    string Address,
    int FaxNumber,
    string Email,
    AgencyExcursionResponse[] Excursions,
    AgencyHotelDealResponse[] HotelDeals
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