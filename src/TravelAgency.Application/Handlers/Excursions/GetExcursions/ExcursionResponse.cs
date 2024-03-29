namespace TravelAgency.Application.Handlers.Excursions.GetExcursions;
public record ExcursionResponse(
    Guid Id, 
    string Location,
    decimal Price,
    DateTime ArrivalDate,
    ExcursionAgencyResponse Agency);

public record ExcursionAgencyResponse(
    string Name,
    string Address,
    int FaxNumber,
    string Email);