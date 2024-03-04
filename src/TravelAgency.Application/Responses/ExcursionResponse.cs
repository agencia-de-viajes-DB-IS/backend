using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Responses;

public record ExcursionResponse(
    string Location,
    decimal Price,
    DateTime ArrivalDate,
    ExcursionAgencyResponse Agency);

public record ExcursionAgencyResponse(
    string Name,
    string Address,
    int FaxNumber,
    string Email);