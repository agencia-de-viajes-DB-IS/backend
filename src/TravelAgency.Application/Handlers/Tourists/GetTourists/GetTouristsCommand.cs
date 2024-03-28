using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;

namespace TravelAgency.Application.Handlers.Tourists.GetTourists;

public record GetTouristsCommand : IRequest<TouristResponse[]>;