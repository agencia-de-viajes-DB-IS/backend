using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Statistics.Queries.ReservationStats;

public class GetReservationStatsCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetReservationStatsCommand, AgencyDto[]>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<AgencyDto[]> Handle(GetReservationStatsCommand request, CancellationToken cancellationToken)
    {
        var packageReservationRepo = _unitOfWork.GetRepository<PackageReservation>();
        Dictionary<Guid, AgencyDto> dict = [];
        var packageReservations = (await packageReservationRepo.FindAllAsync([x => x.Package.ExtendedExcursions!])).ToArray();
        foreach (var pk in packageReservations)
        {
            if (pk.Package.ExtendedExcursions!.Count > 0)
            {
                var agId = pk.Package.ExtendedExcursions.First().AgencyId;
                if (!dict.TryGetValue(agId, out AgencyDto? value))
                {
                    var agencyName = (await _unitOfWork.GetRepository<Agency>().FindAsync(filters: [x => x.Id == agId]))!.Name;
                    value = new AgencyDto(agencyName);
                    dict.Add(agId, value);
                }
                value.PckReserv++;
                value.TotalAmount += pk.Price;
            }
        }
        var excursionReservation = (await _unitOfWork.GetRepository<ExcursionReservation>().FindAllAsync()).ToArray();
        foreach (var ex in excursionReservation)
        {
            var agId = ex.Excursion.AgencyId;
            if (!dict.TryGetValue(agId, out AgencyDto? value))
            {
                var agencyName = (await _unitOfWork.GetRepository<Agency>().FindAsync(filters: [x => x.Id == agId]))!.Name;
                value = new AgencyDto(agencyName);
                dict.Add(agId, value);
            }
            value.ExcReserv++;
            value.TotalAmount += ex.Price;
        }
        var dtos = dict.Values.ToArray();
        var totalAmount = dtos.Sum(x => x.TotalAmount);
        return dtos;
    }
}