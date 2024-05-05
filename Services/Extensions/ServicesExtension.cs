using Microsoft.Extensions.DependencyInjection;

namespace Services.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<AuthService>();
        return services;
    }
}