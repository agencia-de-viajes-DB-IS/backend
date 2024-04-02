using TravelAgency.Application.Handlers.Agencies.GetAgencies;
using TravelAgency.Application.Handlers.Excursions.GetExcursions;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;

namespace TravelAgency.Application.Handlers.Statistics.Queries;
public class GetAllStatisticsResponse
{
    // TODO: fill this thing 
    public decimal TotalReservationFound { get; set; }
    public TouristResponse[]? MostTravelersTourists { get; set; }
    public int OverPricePackagesCount { get; internal set; }
}

class AgencyWithMostSoldExcursion
{
    public GetAgencyResponse Agency { get; set; } = null!;
    public GetExcursionResponse? Excursion { get; set; } = null!;
}