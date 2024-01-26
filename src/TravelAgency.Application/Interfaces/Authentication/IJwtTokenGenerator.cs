using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}