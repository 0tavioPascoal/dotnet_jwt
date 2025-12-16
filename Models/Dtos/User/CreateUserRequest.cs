using System.ComponentModel.DataAnnotations;

namespace dotnet_jwt.Models.Dtos.User;

public record CreateUserRequest(
    [Required, StringLength(80)] string Name,
    [Required, EmailAddress] string Email,
    [Required, MinLength(6)] string Password
    );