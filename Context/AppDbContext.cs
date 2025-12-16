using dotnet_jwt.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_jwt.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}