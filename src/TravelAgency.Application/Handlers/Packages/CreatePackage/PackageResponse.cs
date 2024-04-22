using TravelAgency.Application.Handlers.Agencies.GetAgencies;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Packages.GetPackages;

public record PackageResponse(
    string Code,
    string Name,
    string Description,
    decimal Price,
    int Capacity,
    Guid AgencyId,
    DateTime ArrivalDate,
    DateTime DepartureDate,
    FacilityResponse[] Facilities,
    ExtendedExcursionResponse[] ExtendedExcursions
);

public record ExtendedExcursionResponse(
    Guid Id,
    string Name,
    string Location,
    decimal Price,
    DateTime ArrivalDate,
    DateTime DepartureDate
);