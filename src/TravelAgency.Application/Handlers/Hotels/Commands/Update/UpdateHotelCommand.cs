namespace TravelAgency.Application.Handlers.Hotels.Commands.Update;
using MediatR;
using TravelAgency.Domain.Entities;

public record UpdateHotelCommand(
    Guid Id,
    string? Name,
    string? Description,
    string? Address, 
    int? Category, 
    ICollection<HotelDeal>? Deals
) : IRequest<UpdateHotelResponse>{}
