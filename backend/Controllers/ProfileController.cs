using Backend.Auth;
using Backend.Database.Entities;
using Backend.Models.Dtos;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("me")]
[Authorize]
public class ProfileController(ProfileService profiles) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        var user = await profiles.GetOrCreateAsync(User.GetUserId(), User.GetEmail());
        return Ok(ToResponse(user));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest req)
    {
        var user = await profiles.UpdateAsync(User.GetUserId(), req);
        return user is null ? NotFound() : Ok(ToResponse(user));
    }

    private static ProfileResponse ToResponse(UserEntity u) =>
        new(u.Id, u.Email, u.DisplayName, u.AvatarUrl, u.Location, u.Bio, u.InstagramHandle, u.TikTokHandle);
}
