using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Packages.GetPackages;

public class PackageResponse : BaseResponse
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public FacilityResponse[]? Facilities { get; set; }
    public ExtendedExcursionResponse[]? ExtendedExcursions { get; set; }
}


public record ExtendedExcursionResponse(
    Guid Id,
    string Location,
    decimal Price,
    DateTime ArrivalDate,
    DateTime DepartureDate
);