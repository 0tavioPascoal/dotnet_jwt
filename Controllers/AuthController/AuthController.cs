using dotnet_jwt.Models;
using dotnet_jwt.Models.Dtos.Auth;
using dotnet_jwt.Services;
using dotnet_jwt.Services.Token;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_jwt.Controllers.AuthController;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase 
{
    
    private readonly ITokenService  _tokenService;
    private readonly IAuthService _authService;
    
    public AuthController(ITokenService tokenService, IAuthService authService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _authService.LoginAsync(dto);

        if (token == null)
            return Unauthorized("Usuário ou senha inválidos");

        return Ok(new { token });
    }

    
}