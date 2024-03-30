using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using System.Linq.Expressions;

namespace TravelAgency.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private static readonly string Permissions = "Permissions";
    private static readonly string Role = "role";
    private readonly JwtSettings _jwtSettings;
    private readonly IUnitOfWork _unitOfWork;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettingsOptions, IUnitOfWork unitOfWork)
    {
        _jwtSettings = jwtSettingsOptions.Value;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> GenerateToken(User user)
    {
        var rolesRepo = _unitOfWork.GetRepository<Role>(); 
        var key = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );
        var role = await rolesRepo.FindAsync(null, filters:new Expression<Func<Domain.Entities.Role, bool>>[]
        {
            r => r.Id == user.RoleId
        }) ?? throw new TravelAgencyException("Operation Error", status: 500);
        var permissions = role.Permissions.Select(x => x.ToString());

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(Role,role.Name),
            new Claim(Permissions,JsonSerializer.Serialize(permissions),JsonClaimValueTypes.JsonArray),
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