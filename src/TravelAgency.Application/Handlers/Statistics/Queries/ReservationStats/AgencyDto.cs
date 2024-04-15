namespace TravelAgency.Application.Handlers.Statistics.Queries.ReservationStats;

public class AgencyDto(string name)
{
    public string Name { get; set; } = name;
    public int PckReserv { get; set; } = 0;
    public int ExcReserv { get; set; } = 0;
    public decimal TotalAmount { get; set; } = 0;
};