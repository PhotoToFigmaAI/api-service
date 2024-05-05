using System.Text;
using Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Common.Models.Settings;

public class AuthOptions : IAuthOptions
{
    public string Issuer { get; }
    public string Audience { get; }
    public string Lifetime { get; }
    public string Key { get; }

    public AuthOptions(IConfiguration configuration)
    {
        Issuer = configuration["Auth:Issuer"];
        Audience = configuration["Auth:Audience"];
        Key = configuration["Auth:Key"];
        Lifetime = configuration["Auth:ValidateLifeTimeInMinute"];
    }

    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}