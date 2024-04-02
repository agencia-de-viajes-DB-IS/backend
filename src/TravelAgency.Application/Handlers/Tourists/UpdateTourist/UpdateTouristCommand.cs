using MediatR;

namespace TravelAgency.Application.Handlers.Tourists.UpdateTourist;

public record UpdateTouristCommand(
    Guid TouristId,
    string CI,
    string FirstName,
    string LastName,
    string Nationality
) : IRequest<UpdateTouristResponse>;
