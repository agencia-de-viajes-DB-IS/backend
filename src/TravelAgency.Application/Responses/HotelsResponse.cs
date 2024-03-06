using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Responses;

public record HotelsResponse(
    string Name, 
    string Address,
    ICollection<HotelDeal>? Deals,
    int Category,
    Guid Id
);