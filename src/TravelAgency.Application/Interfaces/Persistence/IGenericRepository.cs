using System.Linq.Expressions;

namespace TravelAgency.Application.Interfaces.Persistence;

public interface IGenericRepository<T> where T : class
{
    // Queries
    Task<T?> FindAsync(IEnumerable<Expression<Func<T, object>>>? includes,
        IEnumerable<Expression<Func<T, bool>>>? filters);
    Task<IEnumerable<T>> FindAllAsync(IEnumerable<Expression<Func<T, object>>>? includes,
        IEnumerable<Expression<Func<T, bool>>>? filters);

    // Commands
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(object id);
}