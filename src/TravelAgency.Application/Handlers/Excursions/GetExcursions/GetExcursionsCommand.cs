using MediatR;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Excursions.GetExcursions;

public record GetExcursionsCommand : IRequest<GetExcursionResponse[]>
{
    public Guid AgencyIdFilter { get; set; } = default;
    public string NameFilter { get; set; } = "";
    public string LocationFilter { get; set; } = "";
    public decimal PriceFilter { get; set; } = default;
    public int CapacityFilter { get; set; } = 0;
    public DateTime ArrivalDateFilter { get; set; } = default;
    public bool IncludeExtended { get; set; }
}