using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Interfaces.Persistence;

public interface IUserRepository
{
    public Task<User?> GetUserByEmail(string email);
    public Task Add(User user);
}