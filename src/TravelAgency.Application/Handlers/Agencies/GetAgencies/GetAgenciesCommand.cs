using MediatR;

namespace TravelAgency.Application.Handlers.Agencies.GetAgencies;

public class GetAgenciesCommand : IRequest<GetAgencyResponse[]>
{
    public string NameFilter { get; set; } = "";

    public string AddressFilter { get; set; } = "";
    public  int FaxNumberFilter { get; set; } 
    public string EmailFilter { get; set; } = "";
}