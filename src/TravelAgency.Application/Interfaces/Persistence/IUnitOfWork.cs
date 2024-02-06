namespace TravelAgency.Application.Interfaces.Persistence;

public interface IUnitOfWork
{
    Task SaveAsync();
}