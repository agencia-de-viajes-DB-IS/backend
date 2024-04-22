using MediatR;

namespace TravelAgency.Application.Handlers.Packages.GetPackages;

public record GetPackagesCommand(
    decimal? PriceFilter,
    DateTime? ArrivalDateFilter,
    DateTime? DepartureDateFilter
) : IRequest<GetPackageResponse[]>;