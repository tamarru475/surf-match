using Backend.Auth;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("me/preferences")]
[Authorize]
public class PreferencesController(PreferencesService prefs, ProfileService profiles) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPreferences()
    {
        var result = await prefs.GetAsync(User.GetUserId());
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpsertPreferences([FromBody] UserPreferences req)
    {
        // Ensure user row exists before inserting preferences (FK constraint).
        await profiles.GetOrCreateAsync(User.GetUserId(), User.GetEmail());
        var result = await prefs.UpsertAsync(User.GetUserId(), req);
        return Ok(result);
    }
}
