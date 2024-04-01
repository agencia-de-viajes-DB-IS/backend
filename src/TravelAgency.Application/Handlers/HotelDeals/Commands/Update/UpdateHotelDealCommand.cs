using System.ComponentModel.DataAnnotations;
using MediatR;
using TravelAgency.Domain.Entities;
namespace TravelAgency.Application.Handlers.HotelDeals.Commands.Update;

public record UpdateHotelDealCommand(
    Guid Id, 
    DateTime? ArrivalDate,
    DateTime? DepartureDate,
    ICollection<AgencyRelatedHotelDeal>? AgencyRelatedHotelDeals,
    ICollection<ExtendedExcursion>? ExtendedExcursions,
    Guid? HotelId,
    decimal? Price,
    string? Description,
    int Capacity
) : IRequest<UpdateHotelDealResponse>{}
