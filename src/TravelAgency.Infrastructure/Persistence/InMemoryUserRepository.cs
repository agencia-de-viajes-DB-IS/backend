using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>();
    public void Add(User user) => _users.Add(user);

    public User? GetUserByEmail(string email) => _users.FirstOrDefault(u => u.Email == email);
}