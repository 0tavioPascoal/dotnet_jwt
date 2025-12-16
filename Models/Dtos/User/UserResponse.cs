namespace dotnet_jwt.Models.Dtos.User;

public record UserResponse(
    Guid Id,
    string Name,
    string Email,
    string Role);