using TravelAgency.Application.Handlers.Agencies.GetAgencies;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Packages.GetPackages;

public record GetPackageResponse(
    string Code,
    string Name,
    string Description,
    decimal Price,
    int Capacity,
    PackageAgencyResponse Agency,
    DateTime ArrivalDate,
    DateTime DepartureDate,
    FacilityResponse[] Facilities,
    ExtendedExcursionResponse[] ExtendedExcursions
);

public record PackageAgencyResponse(
    Guid Id,
    string Name
);