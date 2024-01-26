using FastEndpoints;
using FastEndpoints.Swagger;

namespace TravelAgency.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddFastEndpoints().SwaggerDocument();
        return services;
    }
}