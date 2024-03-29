using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    Task<string> GenerateToken(User user);
}