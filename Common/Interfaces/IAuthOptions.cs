using Microsoft.IdentityModel.Tokens;

namespace Common.Interfaces;

public interface IAuthOptions
{
    string Issuer { get; }
    string Audience { get; }
    string Lifetime { get; }
    string Key { get; }

    public SymmetricSecurityKey GetSymmetricSecurityKey();
}