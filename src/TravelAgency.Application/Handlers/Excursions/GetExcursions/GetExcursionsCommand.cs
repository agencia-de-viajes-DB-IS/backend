using MediatR;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Excursions.GetExcursions;

public record GetExcursionsCommand : IRequest<IEnumerable<ExcursionResponse>> 
{   
    
}