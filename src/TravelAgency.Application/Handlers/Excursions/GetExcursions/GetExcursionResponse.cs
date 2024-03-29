using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Excursions.GetExcursions;

public class GetExcursionResponse : BaseResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public decimal Price { get; set; }
    public DateTime ArrivalDate { get; set; }
    public ExcursionAgencyResponse Agency { get; set; }

    public GetExcursionResponse(Guid id, string name, string description, string location, decimal price, DateTime arrivalDate, ExcursionAgencyResponse agency)
    {
        Id = id;
        Name = name;
        Description = description;
        Location = location;
        Price = price;
        ArrivalDate = arrivalDate;
        Agency = agency;
    }
}

public record ExcursionAgencyResponse(
    string Name,
    string Address,
    int FaxNumber,
    string Email);