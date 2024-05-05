using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Models.settings;

public class DapperSettings : IDapperSettings
{
    public string ConnectionString { get; }

    public DapperSettings(IConfiguration configuration)
    {
        ConnectionString = configuration["Database:connection"] ?? throw new ArgumentException();
    }
}