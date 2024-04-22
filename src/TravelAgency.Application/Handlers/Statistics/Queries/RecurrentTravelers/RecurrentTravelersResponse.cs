namespace TravelAgency.Application.Handlers.Statistics.Queries.RecurrentTravelers
{
    public class RecurrentTravelersResponse
    {
        public RecurrentTravelersResponse(string cI, string firstName, string lastName, int count)
        {
            CI = cI;
            FirstName = firstName;
            LastName = lastName;
            Count = count;
        }

        public string CI { get; internal set; } = null!;
        public string FirstName { get; internal set; } = null!;
        public string LastName { get; internal set; } = null!;    
        public int Count { get; set; }    
    }
}