using dotnet_jwt.Models.Dtos.User;

namespace dotnet_jwt.Services.User;

public interface IUserService
{
    Task<UserResponse> CreateUserAsync(CreateUserRequest request);
    Task<UserResponse?> GetUserByIdAsync(Guid id);
    Task<UserResponse?> GetUserByUsernameAsync(string username);
}