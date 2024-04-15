using System.Linq.Expressions;
using MediatR;

namespace TravelAgency.Application.Handlers.Statistics.Queries.ReservationStats;

public class GetReservationStatsCommand : IRequest<AgencyDto[]>
{

}
