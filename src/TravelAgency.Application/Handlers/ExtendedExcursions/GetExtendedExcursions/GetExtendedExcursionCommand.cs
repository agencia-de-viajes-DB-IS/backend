using MediatR;

namespace TravelAgency.Application.Handlers.ExtendedExcursions.GetExtendedExcursions;

public class GetExtendedExcursionCommand : IRequest<GetExtendedExcursionResponse[]>
{
    public Guid AgencyIdFilter { get; set; } = default;
    public string NameFilter { get; set; } = "";
    public string LocationFilter { get; set; } = "";
    public decimal PriceFilter { get; set; } = default;
    public DateTime ArrivalDateFilter { get; set; } = default;
    public DateTime DepartureDateFilter { get; set; } = default;
    public Guid HoteDealIdFilter { get; set; } = default;
}
