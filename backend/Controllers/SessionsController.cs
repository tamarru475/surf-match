using Backend.Auth;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("me/sessions")]
[Authorize]
public class SessionsController(SurfSessionService sessions, ProfileService profiles) : ControllerBase
{
    [HttpPost("{spotId:guid}")]
    public async Task<IActionResult> LogSession(Guid spotId)
    {
        await profiles.GetOrCreateAsync(User.GetUserId(), User.GetEmail());
        var result = await sessions.LogAsync(User.GetUserId(), spotId);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("last")]
    public async Task<IActionResult> GetLastSession()
    {
        var result = await sessions.GetLastAsync(User.GetUserId());
        return result is null ? NotFound() : Ok(result);
    }
}
