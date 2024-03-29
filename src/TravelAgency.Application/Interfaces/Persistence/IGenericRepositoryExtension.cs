using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Interfaces.Persistence;

public static class IGenericRepositoryExtension
{
    public static async Task<ICollection<Tourist>> StoreRequestTourists(this IGenericRepository<Tourist> touristRepo, IEnumerable<CreateTouristCommand> requestTourists)
    {
        var tourists = new List<Tourist>();

        foreach(var requestTourist in requestTourists)
        {
            var storedTourist = await touristRepo.FindAsync(filters: [tourist => tourist.Id == requestTourist.Id]);

            if(storedTourist is null)
            {
                var newTourist = new Tourist()
                {
                    Id = requestTourist.Id,
                    FirstName = requestTourist.FirstName,
                    LastName = requestTourist.LastName,
                    Nationality = requestTourist.Nationality
                };

                await touristRepo.InsertAsync(newTourist);
                tourists.Add(newTourist);
            }
            else
            {
                tourists.Add(storedTourist);
            }
        }

        return tourists;
    }
}