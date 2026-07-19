using Backend.Database;
using Backend.Database.Entities;
using Backend.Models.Enums;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Tests;

public class SurfSessionServiceTests
{
    private static AppDbContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    private static readonly Guid UserId = Guid.NewGuid();

    private static SurfSpotEntity MakeSpot(Guid id, string name = "Test Spot") => new()
    {
        Id               = id,
        Name             = name,
        Region           = "Auckland",
        WaveType         = "BeachBreak",
        MinSkillLevel    = "Beginner",
        SuitableBoardTypes = ["Longboard"],
        Facilities       = ["Bathrooms"],
        TypicalCrowd     = "Moderate",
        MinWaveSize      = "KneeHigh",
        MaxWaveSize      = "HeadHigh",
        CurrentWaveSize  = "WaistHigh",
        Description      = "A test spot.",
        CreatedAt        = DateTime.UtcNow,
    };

    [Fact]
    public async Task LogAsync_returns_null_for_unknown_spot()
    {
        using var db = CreateDb();
        var result = await new SurfSessionService(db).LogAsync(UserId, Guid.NewGuid());
        Assert.Null(result);
    }

    [Fact]
    public async Task LogAsync_creates_session_and_returns_details()
    {
        using var db = CreateDb();
        var spotId = Guid.NewGuid();
        db.SurfSpots.Add(MakeSpot(spotId, "Piha"));
        await db.SaveChangesAsync();

        var result = await new SurfSessionService(db).LogAsync(UserId, spotId);

        Assert.NotNull(result);
        Assert.Equal(spotId, result.SpotId);
        Assert.Equal("Piha", result.SpotName);
        Assert.Equal(WaveSize.WaistHigh, result.CurrentWaveSize);
        Assert.Single(await db.SurfSessions.ToListAsync());
    }

    [Fact]
    public async Task LogAsync_allows_multiple_sessions_for_same_spot()
    {
        using var db = CreateDb();
        var spotId = Guid.NewGuid();
        db.SurfSpots.Add(MakeSpot(spotId));
        await db.SaveChangesAsync();

        var svc = new SurfSessionService(db);
        await svc.LogAsync(UserId, spotId);
        await svc.LogAsync(UserId, spotId);

        Assert.Equal(2, await db.SurfSessions.CountAsync());
    }

    [Fact]
    public async Task GetLastAsync_returns_null_when_no_sessions()
    {
        using var db = CreateDb();
        var result = await new SurfSessionService(db).GetLastAsync(UserId);
        Assert.Null(result);
    }

    [Fact]
    public async Task GetLastAsync_returns_most_recent_session()
    {
        using var db = CreateDb();
        var spotId1 = Guid.NewGuid();
        var spotId2 = Guid.NewGuid();
        db.SurfSpots.AddRange(MakeSpot(spotId1, "Piha"), MakeSpot(spotId2, "Muriwai"));
        db.SurfSessions.AddRange(
            new SurfSessionEntity { Id = Guid.NewGuid(), UserId = UserId, SpotId = spotId1, SurfedAt = DateTime.UtcNow.AddDays(-2), CreatedAt = DateTime.UtcNow },
            new SurfSessionEntity { Id = Guid.NewGuid(), UserId = UserId, SpotId = spotId2, SurfedAt = DateTime.UtcNow.AddDays(-1), CreatedAt = DateTime.UtcNow }
        );
        await db.SaveChangesAsync();

        var result = await new SurfSessionService(db).GetLastAsync(UserId);

        Assert.NotNull(result);
        Assert.Equal("Muriwai", result.SpotName);
    }

    [Fact]
    public async Task GetLastAsync_only_returns_sessions_for_the_requesting_user()
    {
        using var db = CreateDb();
        var spotId = Guid.NewGuid();
        db.SurfSpots.Add(MakeSpot(spotId));
        db.SurfSessions.Add(new SurfSessionEntity
        {
            Id = Guid.NewGuid(), UserId = Guid.NewGuid(), SpotId = spotId,
            SurfedAt = DateTime.UtcNow, CreatedAt = DateTime.UtcNow,
        });
        await db.SaveChangesAsync();

        var result = await new SurfSessionService(db).GetLastAsync(UserId);

        Assert.Null(result);
    }
}
