using Backend.Database;
using Backend.Database.Entities;
using Backend.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class ProfileService(AppDbContext db)
{
    // Creates the user row on first login; subsequent calls are a fast PK lookup.
    public async Task<UserEntity> GetOrCreateAsync(Guid userId, string email)
    {
        var user = await db.Users.FindAsync(userId);
        if (user is not null)
            return user;

        user = new UserEntity
        {
            Id = userId,
            Email = email,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        db.Users.Add(user);
        try
        {
            await db.SaveChangesAsync();
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
        {
            // Concurrent request beat us to the insert — clear the tracker and
            // re-fetch the row that was just created by the other request.
            db.ChangeTracker.Clear();
            user = await db.Users.FindAsync(userId)
                ?? throw new InvalidOperationException($"User {userId} not found after concurrent insert.");
        }
        return user;
    }

    public async Task<UserEntity> UpdateAsync(Guid userId, string email, UpdateProfileRequest req)
    {
        // GetOrCreateAsync ensures the row exists even if PUT /me is called
        // before GET /me (which normally creates it).
        var user = await GetOrCreateAsync(userId, email);
        user.DisplayName     = req.DisplayName;
        user.Location        = req.Location;
        user.Bio             = req.Bio;
        user.InstagramHandle = req.InstagramHandle;
        user.TikTokHandle    = req.TikTokHandle;
        user.UpdatedAt = DateTime.UtcNow;
        await db.SaveChangesAsync();
        return user;
    }

    public async Task<UserEntity?> UpdateAvatarUrlAsync(Guid userId, string url)
    {
        var user = await db.Users.FindAsync(userId);
        if (user is null) return null;

        user.AvatarUrl = url;
        user.UpdatedAt = DateTime.UtcNow;
        await db.SaveChangesAsync();
        return user;
    }
}
