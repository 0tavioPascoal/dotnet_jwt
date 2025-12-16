using dotnet_jwt.Models;
using dotnet_jwt.Models.Dtos.Auth;
using dotnet_jwt.Repositories;
using dotnet_jwt.Services.Token;

namespace dotnet_jwt.Services;

public interface IAuthService
{
    Task<string?> LoginAsync(LoginDto loginDto);
}