using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace TravelAgency.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private const string Roles = "roles";
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettingsOptions)
    {
        _jwtSettings = jwtSettingsOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var key = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(Roles, user.Role!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            signingCredentials: key,
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.MinutesToExpire),
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}