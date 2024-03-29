using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Hotels.Queries.GetAll; 
public record GetHotelsResponse(
    string Name, 
    string Address,
    ICollection<HotelDeal>? Deals,
    int Category,
    Guid Id
);