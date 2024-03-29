namespace TravelAgency.Application.Handlers.Excursions.CreateExcursions;

public record CreateExcursionDto
(
    Guid Id,
    string Location,
    decimal Price,
    DateTime ArrivalDate
);