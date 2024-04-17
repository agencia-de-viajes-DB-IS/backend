using System.ComponentModel.DataAnnotations;
using MediatR;
using TravelAgency.Domain.Entities;
namespace TravelAgency.Application.Handlers.HotelDeals.Commands.Create;

public record CreateHotelDealCommand(
    DateTime ArrivalDate,
    DateTime DepartureDate,
    Guid HotelId,
    decimal Price,
    string? Description,
    string Name,
    int Capacity
) : IRequest<CreateHotelDealResponse>{}
