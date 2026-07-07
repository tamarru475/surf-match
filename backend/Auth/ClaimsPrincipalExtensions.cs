using System.Security.Claims;

namespace Backend.Auth;

public static class ClaimsPrincipalExtensions
{
    // Supabase puts the user's UUID in the standard 'sub' claim.
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var sub = user.FindFirstValue(ClaimTypes.NameIdentifier)
               ?? user.FindFirstValue("sub")
               ?? throw new UnauthorizedAccessException("No user ID claim found.");

        return Guid.Parse(sub);
    }
}
