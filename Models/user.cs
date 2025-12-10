using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dotnet_jwt.Models.Enuns;

namespace dotnet_jwt.Models;

[Table("Users")]
public class user
{

    [Key] public Guid UserId { get; set; } = Guid.NewGuid();

    [Required, StringLength(80)] public string Name { get; set; }

    [Required, EmailAddress] public string Email { get; set; }

    [Required, StringLength(20)] public string Password { get; set; }

    [Required]
    public roleUser Roles { get; private set; } = roleUser.USER;
}

