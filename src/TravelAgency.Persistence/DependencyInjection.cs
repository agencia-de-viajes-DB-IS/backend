using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelAgency.Persistence.Models;

namespace TravelAgency.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContext<AeroSkullContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("AeroSkullConnection")!));
        return services;
    }
    
}