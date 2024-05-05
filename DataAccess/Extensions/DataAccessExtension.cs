using System.Reflection;
using DataAccess.Dapper;
using DataAccess.Interfaces;
using DataAccess.Models.settings;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class DataAccessExtension
{
    public static IServiceCollection AddDapperContext(this IServiceCollection services)
    {
        services.AddScoped<IDapperSettings, DapperSettings>();
        services.AddScoped<IDapperContext, DapperContext>();
        return services;
    }

    public static IServiceCollection AddDatabaseMigration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLogging(c => c.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddPostgres()
                .WithGlobalConnectionString(configuration["Database:Connection"])
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());
        return services;
    }

    public static IServiceProvider MakeMigrate(this IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();
        return serviceProvider;
    }
}