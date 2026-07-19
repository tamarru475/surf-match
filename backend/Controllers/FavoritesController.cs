using Backend.Auth;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("me/favorites")]
[Authorize]
public class FavoritesController(FavoritesService favs, ProfileService profiles) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetFavorites() =>
        Ok(await favs.GetAsync(User.GetUserId()));

    [HttpPost("{spotId:guid}")]
    public async Task<IActionResult> AddFavorite(Guid spotId)
    {
        await profiles.GetOrCreateAsync(User.GetUserId(), User.GetEmail());
        var result = await favs.AddAsync(User.GetUserId(), spotId);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{spotId:guid}")]
    public async Task<IActionResult> RemoveFavorite(Guid spotId)
    {
        var removed = await favs.RemoveAsync(User.GetUserId(), spotId);
        return removed ? NoContent() : NotFound();
    }
}
