using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Excursions.GetExcursions;

public class GetExcursionResponse : BaseResponse
{
    Guid Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string Location { get; set; }
    decimal Price { get; set; }
    DateTime ArrivalDate { get; set; }
    ExcursionAgencyResponse Agency { get; set; }

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