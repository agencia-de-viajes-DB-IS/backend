using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Application.Interfaces.Persistence;

namespace TravelAgency.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AeroSkullDbContext _context;
    private readonly DbSet<T> _set;
    public GenericRepository(AeroSkullDbContext context)
    {
        _context = context;
        _set = _context.Set<T>();
    }
    public async Task DeleteAsync(object id)
    {
        var entity = await _set.FindAsync(id) ?? throw new Exception("Entity was not found");
        _set.Remove(entity);
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await Task.Run(() => _set.Where(predicate));
    }

    public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await Task.Run(() => _set.Where(predicate).FirstOrDefault());
    }

    public async Task InsertAsync(T entity)
    {
        await _set.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        await Task.Run(() => _set.Attach(entity));
        _context.Entry(entity).State = EntityState.Modified;
    }
}