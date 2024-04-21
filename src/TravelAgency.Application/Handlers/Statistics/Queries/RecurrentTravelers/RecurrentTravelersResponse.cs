
namespace TravelAgency.Application.Handlers.Statistics.Queries.RecurrentTravelers
{
    public class RecurrentTravelersResponse
    {
        public TouristDto[]? Tourists { get; internal set; }
    }
    public class TouristDto
    {
        public Guid TouristID { get; internal set; }
        public Guid UserId { get; internal set; }
        public string CI { get; internal set; } = null!;
        public string FirstName { get; internal set; } = null!;
        public string LastName { get; internal set; } = null!;
        public string Nationality { get; internal set; } = null!;
    }
}