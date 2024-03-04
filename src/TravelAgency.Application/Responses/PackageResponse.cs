using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Responses;

public record PackageResponse(
    string Code,
    string Description,
    decimal Price,
    DateTime ArrivalDate,
    DateTime DepartureDate,
    IEnumerable<Facility> Facilities,
    IEnumerable<ExtendedExcursion> ExtendedExcursions
);