using TravelAgency.Application.Handlers.Excursions.GetExcursions;

namespace TravelAgency.Application.Handlers.ExtendedExcursions.GetExtendedExcursions;

public class GetExtendedExcursionResponse
{
    public GetExtendedExcursionResponse(Guid id, string name, string description, string location, decimal price, DateTime arrivalDate, ExcursionAgencyResponse agency, DateTime departureDate, IEnumerable<GetExtendedExcursionHotelDealResponse> hotelDeals)
    {
        Id = id;
        Name = name;
        Description = description;
        Location = location;
        Price = price;
        ArrivalDate = arrivalDate;
        Agency = agency;
        DepartureDate = departureDate;
        HotelDeals = hotelDeals;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public decimal Price { get; set; }
    public DateTime ArrivalDate { get; set; }
    public ExcursionAgencyResponse Agency { get; set; }
    public DateTime DepartureDate { get; set; }
    public IEnumerable<GetExtendedExcursionHotelDealResponse> HotelDeals { get; set; }
}
