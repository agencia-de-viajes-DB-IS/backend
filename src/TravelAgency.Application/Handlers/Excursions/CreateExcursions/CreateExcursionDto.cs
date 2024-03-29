namespace TravelAgency.Application.Handlers.Excursions.CreateExcursions;

public record CreateExcursionDto
(
    Guid Id,
    string Name,
    string Description,
    string Location,
    decimal Price,
    DateTime ArrivalDate
);