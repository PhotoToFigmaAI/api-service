using Microsoft.AspNetCore.Mvc;
using Models.Auth;
using Services;

namespace api_service.Controllers;

[Controller]
[Route("[controller]")]
public class AuthController : BaseController
{
    private AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<RegistrationResponse> Register([FromForm] AuthRequest authRequest)
    {
        return await _authService.RegisterUser(authRequest.Username, authRequest.Password);
    }

    [HttpGet("login")]
    public async Task<RegistrationResponse> Login(AuthRequest authRequest)
    {
        return await _authService.LoginUser(authRequest.Username, authRequest.Password);
    }
}