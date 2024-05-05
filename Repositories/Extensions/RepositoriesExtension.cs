using Microsoft.Extensions.DependencyInjection;

namespace Repositories.Extensions;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<AuthRepository>();
        return services;
    }
}