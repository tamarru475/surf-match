using Backend.Database;
using Backend.Database.Entities;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Tests;

public class PreferencesServiceTests
{
    private static AppDbContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    private static async Task<Guid> SeedUser(AppDbContext db)
    {
        var id = Guid.NewGuid();
        db.Users.Add(new UserEntity { Id = id, Email = "surfer@example.com", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
        await db.SaveChangesAsync();
        return id;
    }

    private static readonly UserPreferences SamplePrefs = new()
    {
        SkillLevel = SkillLevel.Intermediate,
        CrowdTolerance = CrowdLevel.Moderate,
        PreferredRegions = [Region.Auckland, Region.Waikato],
        BoardTypes = [BoardType.Shortboard],
        PreferredWaveTypes = [WaveType.BeachBreak],
        PreferredWaveSizes = [WaveSize.WaistHigh, WaveSize.HeadHigh],
        PreferredFacilities = [],
    };

    [Fact]
    public async Task Get_returns_null_when_no_preferences_saved()
    {
        await using var db = CreateDb();
        var svc = new PreferencesService(db);
        var userId = await SeedUser(db);

        var result = await svc.GetAsync(userId);

        Assert.Null(result);
    }

    [Fact]
    public async Task Upsert_creates_preferences_and_Get_returns_them()
    {
        await using var db = CreateDb();
        var svc = new PreferencesService(db);
        var userId = await SeedUser(db);

        await svc.UpsertAsync(userId, SamplePrefs);
        var result = await svc.GetAsync(userId);

        Assert.NotNull(result);
        Assert.Equal(SkillLevel.Intermediate, result.SkillLevel);
        Assert.Equal(CrowdLevel.Moderate, result.CrowdTolerance);
        Assert.Equal([Region.Auckland, Region.Waikato], result.PreferredRegions);
        Assert.Equal([BoardType.Shortboard], result.BoardTypes);
        Assert.Equal([WaveType.BeachBreak], result.PreferredWaveTypes);
    }

    [Fact]
    public async Task Upsert_updates_existing_preferences()
    {
        await using var db = CreateDb();
        var svc = new PreferencesService(db);
        var userId = await SeedUser(db);

        await svc.UpsertAsync(userId, SamplePrefs);

        var updated = new UserPreferences
        {
            SkillLevel = SkillLevel.Advanced,
            CrowdTolerance = CrowdLevel.Quiet,
            BoardTypes = [BoardType.Fish, BoardType.Longboard],
            PreferredWaveTypes = [],
            PreferredWaveSizes = [],
            PreferredFacilities = [Facility.Showers],
        };
        await svc.UpsertAsync(userId, updated);

        Assert.Equal(1, await db.UserPreferences.CountAsync());
        var result = await svc.GetAsync(userId);
        Assert.NotNull(result);
        Assert.Equal(SkillLevel.Advanced, result.SkillLevel);
        Assert.Equal([BoardType.Fish, BoardType.Longboard], result.BoardTypes);
        Assert.Equal([Facility.Showers], result.PreferredFacilities);
        Assert.Empty(result.PreferredRegions);
    }

    [Fact]
    public async Task Upsert_round_trips_empty_regions()
    {
        await using var db = CreateDb();
        var svc = new PreferencesService(db);
        var userId = await SeedUser(db);

        var prefs = new UserPreferences
        {
            SkillLevel = SkillLevel.Beginner,
            CrowdTolerance = CrowdLevel.Quiet,
            PreferredRegions = [],
            BoardTypes = [],
            PreferredWaveTypes = [],
            PreferredWaveSizes = [],
            PreferredFacilities = [],
        };
        await svc.UpsertAsync(userId, prefs);
        var result = await svc.GetAsync(userId);

        Assert.NotNull(result);
        Assert.Empty(result.PreferredRegions);
    }
}
