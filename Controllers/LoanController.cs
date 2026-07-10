using Microsoft.AspNetCore.Mvc;

namespace dotnet_bookish_starter.Controllers;

[ApiController]
[Route("loans")]
public class LoanController : ControllerBase
{ 
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { status = "ok" });
    }
}