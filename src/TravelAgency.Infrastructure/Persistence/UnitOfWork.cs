using TravelAgency.Application.Interfaces.Persistence;

namespace TravelAgency.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AeroSkullDbContext _context;
    public UnitOfWork(AeroSkullDbContext context)
    {
        _context = context;
    }
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}