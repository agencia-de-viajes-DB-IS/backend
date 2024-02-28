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

    public async Task<IEnumerable<T>> FindAllAsync(IEnumerable<Expression<Func<T, object>>>? includes,
        IEnumerable<Expression<Func<T, bool>>>? filters)
    {
        var elements = _set.OfType<T>();
        if (includes != null)
        {
            IEnumerable<Expression<Func<T,object>>> includesArray = includes as Expression<Func<T, object>>[] ?? includes.ToArray();
            if (includesArray.Any())
            {
                includesArray.Aggregate(elements, (current, includeExpression) => current.Include(includeExpression));
            }
        }

        if (filters != null)
        {
            var filtersArray = filters as Expression<Func<T, bool>>[] ?? filters.ToArray();
            if (filtersArray.Any())
            {
                filtersArray.Aggregate(elements, (current, expression) => current.Where(expression));
            }
        }
        return await Task.Run(() => elements);
    }
    

    public async Task<T?> FindAsync(IEnumerable<Expression<Func<T, object>>>? includes,
        IEnumerable<Expression<Func<T, bool>>>? filters) => (await FindAllAsync(includes, filters)).FirstOrDefault();
    

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