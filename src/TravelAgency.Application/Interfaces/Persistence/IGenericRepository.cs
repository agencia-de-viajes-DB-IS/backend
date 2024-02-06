using System.Linq.Expressions;

namespace TravelAgency.Application.Interfaces.Persistence;

public interface IGenericRepository<T> where T : class
{
    // Queries
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);

    // Commands
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(object id);
}