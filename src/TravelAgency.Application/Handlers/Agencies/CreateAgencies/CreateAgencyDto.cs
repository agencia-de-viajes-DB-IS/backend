namespace TravelAgency.Application.Handlers.Agencies.CreateAgencies;

public record CreateAgencyDto(
    Guid Id,
    string Name,
    string Email);