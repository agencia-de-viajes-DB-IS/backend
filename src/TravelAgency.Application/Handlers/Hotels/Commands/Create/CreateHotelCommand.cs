using System.ComponentModel.DataAnnotations;
using MediatR;
using TravelAgency.Domain.Entities;
namespace TravelAgency.Application.Handlers.Hotels.Commands.Create;

public record CreateHotelCommand(
    string Name,
    string Description,
    string Address, 
    int Category, 
    ICollection<HotelDeal> Deals
) : IRequest<CreateHotelResponse>{}
