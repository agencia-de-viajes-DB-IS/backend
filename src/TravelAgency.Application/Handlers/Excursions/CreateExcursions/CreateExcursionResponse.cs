using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Excursions.CreateExcursions;

public class CreateExcursionResponse(Guid id, string name, string description, string location, decimal price, DateTime arrivalDate) : BaseResponse
{
    Guid Id { get; set; } = id;
    string Name { get; set; } = name;
    string Description { get; set; } = description;
    string Location { get; set; } = location;
    decimal Price { get; set; } = price;
    DateTime ArrivalDate { get; set; } = arrivalDate;
}