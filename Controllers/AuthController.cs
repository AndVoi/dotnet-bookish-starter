using Microsoft.AspNetCore.Mvc;

namespace dotnet_bookish_starter.Controllers;

[ApiController]
[Route("login")]
public class AuthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { status = "ok" });
    }
}