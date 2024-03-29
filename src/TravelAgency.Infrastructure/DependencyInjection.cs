using System.Text;
using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.Persistence.Repositories;
using TravelAgency.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Infrastructure;

public static class DependencyInjection
{
    private static bool _isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddAuthorization();

        services.AddDbContext<AeroSkullDbContext>(options =>
        {
            if(_isDevelopment)
                options.UseInMemoryDatabase("AeroSkull");
            else
                options.UseMySQL(configuration.GetConnectionString("AeroSkullConnection")!);
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        // services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SECTION_NAME, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        });

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
        return services;
    }
}