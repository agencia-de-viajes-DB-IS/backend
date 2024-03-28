namespace TravelAgency.Application.Handlers.HotelDeals.Commands.Delete;
using MediatR;

public record DeleteHotelDealCommand(
    Guid Id
) : IRequest<DeleteHotelDealResponse>{}
