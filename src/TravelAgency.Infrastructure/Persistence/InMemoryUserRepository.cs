using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>();
    public Task Add(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }
    public Task<User?> GetUserByEmail(string email)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Email == email));
    }
}