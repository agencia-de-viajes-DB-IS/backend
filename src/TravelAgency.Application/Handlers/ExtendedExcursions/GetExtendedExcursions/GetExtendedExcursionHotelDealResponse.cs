namespace TravelAgency.Application.Handlers.ExtendedExcursions.GetExtendedExcursions;

public class GetExtendedExcursionHotelDealResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public GetExtendedExcursionHotelDealResponse(string name, Guid id)
    {
        Name = name;
        Id = id;
    }
}