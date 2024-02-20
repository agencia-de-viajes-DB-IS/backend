using TravelAgency.Application.Interfaces.Persistence;

namespace TravelAgency.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AeroSkullDbContext _context;

    public UnitOfWork(AeroSkullDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync() => await _context
    .SaveChangesAsync();

    public IGenericRepository<T> GetRepository<T>() where T : class => new GenericRepository<T>(_context);
}