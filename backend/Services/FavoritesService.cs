using Backend.Database;
using Backend.Database.Entities;
using Backend.Models.Dtos;
using Backend.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class FavoritesService(AppDbContext db)
{
    public async Task<List<FavoriteSpotResponse>> GetAsync(Guid userId)
    {
        var favorites = await db.Favorites
            .Where(f => f.UserId == userId)
            .Include(f => f.Spot)
            .OrderByDescending(f => f.CreatedAt)
            .ToListAsync();

        return favorites.Select(f => ToResponse(f, f.Spot)).ToList();
    }

    public async Task<FavoriteSpotResponse?> AddAsync(Guid userId, Guid spotId)
    {
        var spot = await db.SurfSpots.FindAsync(spotId);
        if (spot is null) return null;

        var existing = await db.Favorites
            .FirstOrDefaultAsync(f => f.UserId == userId && f.SpotId == spotId);

        if (existing is not null)
            return ToResponse(existing, spot);

        var favorite = new FavoriteEntity
        {
            Id = Guid.CreateVersion7(),
            UserId = userId,
            SpotId = spotId,
            CreatedAt = DateTime.UtcNow,
            Spot = spot,
            User = null!, // FK-only insert; EF Core populates on load
        };
        db.Favorites.Add(favorite);
        await db.SaveChangesAsync();
        return ToResponse(favorite, spot);
    }

    public async Task<bool> RemoveAsync(Guid userId, Guid spotId)
    {
        var favorite = await db.Favorites
            .FirstOrDefaultAsync(f => f.UserId == userId && f.SpotId == spotId);

        if (favorite is null) return false;

        db.Favorites.Remove(favorite);
        await db.SaveChangesAsync();
        return true;
    }

    private static FavoriteSpotResponse ToResponse(FavoriteEntity f, SurfSpotEntity s) => new(
        SpotId:          s.Id,
        Name:            s.Name,
        Region:          Enum.Parse<Region>(s.Region),
        WaveType:        Enum.Parse<WaveType>(s.WaveType),
        MinSkillLevel:   Enum.Parse<SkillLevel>(s.MinSkillLevel),
        TypicalCrowd:    Enum.Parse<CrowdLevel>(s.TypicalCrowd),
        CurrentWaveSize: Enum.Parse<WaveSize>(s.CurrentWaveSize),
        Facilities:      s.Facilities.Select(fac => Enum.Parse<Facility>(fac)).ToList(),
        Description:     s.Description,
        FavoritedAt:     f.CreatedAt
    );
}
