using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Excursions.CreateExcursions;

public class CreateExcursionResponse(Guid id, string name, string description, string location, decimal price, DateTime arrivalDate) : BaseResponse
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public string Location { get; set; } = location;
    public decimal Price { get; set; } = price;
    public DateTime ArrivalDate { get; set; } = arrivalDate;
}