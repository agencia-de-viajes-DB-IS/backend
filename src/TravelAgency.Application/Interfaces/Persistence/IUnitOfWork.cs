using TravelAgency.Persistence.Models;

namespace TravelAgency.Application.Interfaces.Persistence;

public interface IUnitOfWork
{
    IGenericRepository<T> GetRepository<T>() where T : class;
    Task SaveAsync();
}