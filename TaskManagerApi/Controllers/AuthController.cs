using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Models.Auth;

namespace TaskManagerApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        if (model.Username == "admin" && model.Password == "password")
        {
            var token = _tokenService.GenerateToken(model.Username, "Admin");
            return Ok(new { token });
        }

        return Unauthorized();
    }
}