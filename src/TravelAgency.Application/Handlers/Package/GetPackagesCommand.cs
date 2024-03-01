using MediatR;
using TravelAgency.Api.Responses;

namespace TravelAgency.Application.Handlers.User.GetUsers;

public record GetPackagesCommand : IRequest<IEnumerable<PackageResponse>>;