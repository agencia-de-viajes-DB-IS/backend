using Microsoft.EntityFrameworkCore;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Persistence.Models;

namespace TravelAgency.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AeroSkullContext _context;

    public UnitOfWork(AeroSkullContext context)
    {
        _context = context;
    }
    public async Task SaveAsync() => await _context
    .SaveChangesAsync();
}