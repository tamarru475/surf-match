using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("recommendations")]
public class RecommendationsController(RecommendationEngine engine) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetRecommendations([FromBody] UserPreferences prefs) =>
        Ok(await engine.GetRecommendationsAsync(prefs));
}
