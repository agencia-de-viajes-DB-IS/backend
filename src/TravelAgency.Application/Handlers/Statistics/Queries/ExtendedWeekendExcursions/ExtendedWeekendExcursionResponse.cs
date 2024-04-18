namespace TravelAgency.Application.Handlers.Statistics.Queries.ExtendedWeekendExcursions;

public record ExtendedWeekendExcursionResponse(
    string Location,
    TimeSpan ArrivalTime,
    int Duration
);