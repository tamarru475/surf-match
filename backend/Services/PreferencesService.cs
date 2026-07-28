using Backend.Database;
using Backend.Database.Entities;
using Backend.Models;
using Backend.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class PreferencesService(AppDbContext db)
{
    public async Task<UserPreferences?> GetAsync(Guid userId)
    {
        var entity = await db.UserPreferences.FirstOrDefaultAsync(p => p.UserId == userId);
        return entity is null ? null : ToModel(entity);
    }

    public async Task<UserPreferences> UpsertAsync(Guid userId, UserPreferences prefs)
    {
        var entity = await db.UserPreferences.FirstOrDefaultAsync(p => p.UserId == userId);
        if (entity is null)
        {
            entity = new UserPreferencesEntity { UserId = userId, User = null! }; // FK-only insert; EF Core populates on load
            db.UserPreferences.Add(entity);
        }

        entity.SkillLevel = prefs.SkillLevel.ToString();
        entity.CrowdTolerance = prefs.CrowdTolerance.ToString();
        entity.PreferredRegions = prefs.PreferredRegions.Select(r => r.ToString()).ToList();
        entity.BoardTypes = prefs.BoardTypes.Select(b => b.ToString()).ToList();
        entity.PreferredWaveTypes = prefs.PreferredWaveTypes.Select(w => w.ToString()).ToList();
        entity.PreferredWaveSizes = prefs.PreferredWaveSizes.Select(s => s.ToString()).ToList();
        entity.PreferredFacilities = prefs.PreferredFacilities.Select(f => f.ToString()).ToList();
        entity.UpdatedAt = DateTime.UtcNow;

        await db.SaveChangesAsync();
        return ToModel(entity);
    }

    private static UserPreferences ToModel(UserPreferencesEntity e) => new()
    {
        SkillLevel = Enum.Parse<SkillLevel>(e.SkillLevel),
        CrowdTolerance = Enum.Parse<CrowdLevel>(e.CrowdTolerance),
        PreferredRegions = e.PreferredRegions.Select(Enum.Parse<Region>).ToList(),
        BoardTypes = e.BoardTypes.Select(Enum.Parse<BoardType>).ToList(),
        PreferredWaveTypes = e.PreferredWaveTypes.Select(Enum.Parse<WaveType>).ToList(),
        PreferredWaveSizes = e.PreferredWaveSizes.Select(Enum.Parse<WaveSize>).ToList(),
        PreferredFacilities = e.PreferredFacilities.Select(Enum.Parse<Facility>).ToList(),
    };
}
