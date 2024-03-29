using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Airlines.GetAirlines;

public class GetAirlinesCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAirlinesCommand, AirlineResponse[]>
{
    public async Task<AirlineResponse[]> Handle(GetAirlinesCommand request, CancellationToken cancellationToken)
    {
        var airlineRepo = _unitOfWork.GetRepository<Airline>();

        var airlines = await airlineRepo.FindAllAsync();

        var response = airlines.Select(airline => new AirlineResponse(
            airline.Id,
            airline.Name
        )).ToArray();

        return response;
    }
}