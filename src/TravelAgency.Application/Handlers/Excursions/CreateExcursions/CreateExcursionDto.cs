namespace TravelAgency.Application.Handlers.Excursions.CreateExcursions;

public record CreateExcursionDto
(
    string Location,
    decimal Price,
    DateTime ArrivalDate
);