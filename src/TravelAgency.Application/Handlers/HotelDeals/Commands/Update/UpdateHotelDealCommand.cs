using System.ComponentModel.DataAnnotations;
using MediatR;
using TravelAgency.Domain.Entities;
namespace TravelAgency.Application.Handlers.HotelDeals.Commands.Update;

public record UpdateHotelDealCommand(
    Guid Id,
    string Name,
    string? Description,
    decimal? Price,
    int Capacity,
    Guid? HotelId
) : IRequest<UpdateHotelDealResponse>
{ }
