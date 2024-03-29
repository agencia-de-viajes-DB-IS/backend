using System.Linq.Expressions;

namespace TravelAgency.Application.Interfaces.Persistence;

public interface IGenericRepository<T> where T : class
{
    // Queries
    Task<T?> FindAsync(IEnumerable<Expression<Func<T, object>>>? includes = null, IEnumerable<Expression<Func<T, bool>>>? filters = null);
    Task<IEnumerable<T>> FindAllAsync(IEnumerable<Expression<Func<T, object>>>? includes = null, IEnumerable<Expression<Func<T, bool>>>? filters = null);

    // Commands
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(object id);

    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
}