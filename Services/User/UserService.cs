using dotnet_jwt.Models.Dtos.User;
using dotnet_jwt.Models.Enuns;
using dotnet_jwt.Repositories;

namespace dotnet_jwt.Services.User;

public class UserService : IUserService
{
    
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserResponse> CreateUserAsync(CreateUserRequest request)
    {
        // Regra de negócio: username único
        var existingUser = await _userRepository.GetUserByUsername(request.Name);
        if (existingUser != null)
            throw new InvalidOperationException("Usuário já existe");

        var user = new Models.User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Roles = roleUser.USER
        };

        var createdUser = await _userRepository.CreateUser(user);

        return MapToResponse(createdUser);
    }

    public async Task<UserResponse?> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        return user == null ? null : MapToResponse(user);
    }

    public  async Task<UserResponse?> GetUserByUsernameAsync(string username)
    {
        var user = await _userRepository.GetUserByUsername(username);
        return user == null ? null : MapToResponse(user);
    }
    
    private static UserResponse MapToResponse(Models.User user)
    {
        return new UserResponse(
            user.UserId,
            user.Name,
            user.Email,
            user.Roles.ToString()
        );
    }
}