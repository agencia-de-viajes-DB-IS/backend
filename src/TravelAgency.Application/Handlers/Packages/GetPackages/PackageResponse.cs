namespace TravelAgency.Application.Handlers.Packages.GetPackages;

public record PackageResponse(
    string Code,
    string Description,
    decimal Price,
    DateTime ArrivalDate,
    DateTime DepartureDate,
    IEnumerable<FacilityResponse> Facilities,
    IEnumerable<ExtendedExcursionResponse> ExtendedExcursions
);

public record FacilityResponse(
    int Id,
    string Name,
    string Description
);

public record ExtendedExcursionResponse(
    Guid Id,
    string Location,
    decimal Price,
    DateTime ArrivalDate,
    DateTime DepartureDate
);