using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Common;
using Common.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Models.Auth;
using Repositories;


namespace Services;

public class AuthService
{
    private IAuthOptions _authOptions;
    private AuthRepository _authRepository;
    
    public AuthService(IAuthOptions authOptions, AuthRepository authRepository)
    {
        _authRepository = authRepository;
        _authOptions = authOptions;
    }
    
    public async Task<RegistrationResponse> RegisterUser(string username, string password)
    {
        var res = await _authRepository.AddUser(username, Hash.HashPassword(password));
        var accessToken = GetJwtToken(username, res.Id);
        
        // var c = new JwtSecurityTokenHandler().ReadJwtToken(res);
        // Console.WriteLine(string.Join("\n", c.Payload.Claims.Select(p => p.ToString())));
        return new RegistrationResponse {AccessToken = accessToken, Type = "Bearer"};
    }

    public async Task<RegistrationResponse> LoginUser(string username, string password)
    {
        var user = await _authRepository.GetUserByUsername(username);
        if (user is null)
        {
            throw new ArgumentException("А такого юзера нету");
        }

        if (!Hash.VerifyPassword(password, user.HashedPassword))
        {
            throw new ArgumentException("хуйня");
        }
        
        return new RegistrationResponse { AccessToken = GetJwtToken(user.Username, user.Id), Type = "Bearer"};
    }

    private string GetJwtToken(string username, string userId)
    {
        var claims = new List<Claim> {new Claim(ClaimTypes.Name, username), new Claim("userId", userId)};
        var jwt = new JwtSecurityToken(
            issuer: _authOptions.Issuer,
            audience: _authOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(double.Parse(_authOptions.Lifetime))),
            signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
    
}