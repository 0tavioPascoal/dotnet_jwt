using dotnet_jwt.Models;
using dotnet_jwt.Models.Dtos.Auth;

namespace dotnet_jwt.Services.Token;

public interface ITokenService
{
    Task<string> GenerateToken(Models.User user);
}