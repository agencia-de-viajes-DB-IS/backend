using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Agencies.GetAgencies;

public class GetAgencyResponse : BaseResponse
{
    public GetAgencyResponse(Guid id, string name, string address, int faxNumber, string email)
    {
        Id = id;
        Name = name;
        Address = address;
        FaxNumber = faxNumber;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int FaxNumber { get; set; }
    public string Email { get; set; }
};

public record AgencyHotelDealResponse(
    string Name,
    string Description,
    decimal Price,
    DateTime ArrivalDate, 
    DateTime DepartureDate
    );

public record AgencyExcursionResponse(
    string Location,
    decimal Price,
    DateTime ArrivalDate);
