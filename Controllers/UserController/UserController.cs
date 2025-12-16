using dotnet_jwt.Models.Dtos.User;
using dotnet_jwt.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_jwt.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> CreateUser(
        [FromBody] CreateUserRequest request)
    {
        var user = await _userService.CreateUserAsync(request);

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = user.Id },
            user
        );
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserResponse>> GetUserById(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user is null)
            return NotFound();

        return Ok(user);
    }
}