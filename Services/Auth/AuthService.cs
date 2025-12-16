using dotnet_jwt.Models.Dtos.Auth;
using dotnet_jwt.Repositories;
using dotnet_jwt.Services.Token;

namespace dotnet_jwt.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(
        IUserRepository userRepository,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<string?> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.GetUserByUsername(loginDto.username);

        if (user == null)
            return null;

        var passwordValid = BCrypt.Net.BCrypt.Verify(
            loginDto.Password,
            user.PasswordHash
        );

        if (!passwordValid)
            return null;

        return await _tokenService.GenerateToken(user);
    }
}