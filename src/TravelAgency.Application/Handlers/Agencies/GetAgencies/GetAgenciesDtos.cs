using System.Security.Cryptography.X509Certificates;

namespace TravelAgency.Application.Handlers.Agencies.GetAgencies;

public class GetAgencyDto
{
    public GetAgencyDto(Guid id, string name, string address, int faxNumber, string email, IEnumerable<AgencyExcursionResponse> excursions, IEnumerable<AgencyHotelDealResponse> hotelDeals)
    {
        Id = id;
        Name = name;
        Address = address;
        FaxNumber = faxNumber;
        Email = email;
        Excursions = excursions;
        HotelDeals = hotelDeals;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int FaxNumber { get; set; }
    public string Email { get; set; }
    public IEnumerable<AgencyExcursionResponse> Excursions { get; set; }
    public IEnumerable<AgencyHotelDealResponse> HotelDeals { get; set; }
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