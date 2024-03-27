namespace TravelAgency.Application.Handlers.Hotels.Commands.Delete;
using MediatR;
using TravelAgency.Domain.Entities;

public record DeleteHotelCommand(
    Guid Id
) : IRequest<DeleteHotelResponse>{}
