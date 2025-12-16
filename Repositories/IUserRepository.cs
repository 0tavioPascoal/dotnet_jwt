using dotnet_jwt.Models;

namespace dotnet_jwt.Repositories;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
    Task<User> GetUserById(Guid id);
    
    Task<User?> GetUserByUsername(string username);
}