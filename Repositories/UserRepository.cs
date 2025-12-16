using dotnet_jwt.Context;
using dotnet_jwt.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_jwt.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUser(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> GetUserById(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id inválido", nameof(id));

        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentNullException(nameof(username));

        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Name == username);
    }
}