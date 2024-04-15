using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Statistics.Queries.ReservationStats;

public class ReservationStatsResponse(double totalAmount,  AgencyDto[] values) : BaseResponse
{
    public double TotalAmount = totalAmount;
    public AgencyDto[] Agencies = values;
}
