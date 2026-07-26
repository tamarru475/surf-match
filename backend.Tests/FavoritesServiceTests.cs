using Backend.Database;
using Backend.Database.Entities;
using Backend.Models.Enums;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Tests;

public class FavoritesServiceTests
{
    private static AppDbContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.CreateVersion7().ToString())
            .Options;
        return new AppDbContext(options);
    }

    private static readonly Guid UserId = Guid.CreateVersion7();

    private static SurfSpotEntity MakeSpot(Guid id, string name = "Test Spot") => new()
    {
        Id              = id,
        Name            = name,
        Region          = "Auckland",
        WaveType        = "BeachBreak",
        MinSkillLevel   = "Beginner",
        SuitableBoardTypes = ["Longboard"],
        Facilities      = ["Bathrooms"],
        TypicalCrowd    = "Moderate",
        MinWaveSize     = "KneeHigh",
        MaxWaveSize     = "HeadHigh",
        CurrentWaveSize = "WaistHigh",
        Description     = "A test spot.",
        CreatedAt       = DateTime.UtcNow,
    };

    [Fact]
    public async Task GetAsync_returns_empty_list_when_no_favorites()
    {
        using var db = CreateDb();
        var result = await new FavoritesService(db).GetAsync(UserId);
        Assert.Empty(result);
    }

    [Fact]
    public async Task AddAsync_returns_null_for_unknown_spot()
    {
        using var db = CreateDb();
        var result = await new FavoritesService(db).AddAsync(UserId, Guid.CreateVersion7());
        Assert.Null(result);
    }

    [Fact]
    public async Task AddAsync_creates_favorite_and_returns_spot_details()
    {
        using var db = CreateDb();
        var spotId = Guid.CreateVersion7();
        db.SurfSpots.Add(MakeSpot(spotId, "Piha"));
        await db.SaveChangesAsync();

        var result = await new FavoritesService(db).AddAsync(UserId, spotId);

        Assert.NotNull(result);
        Assert.Equal(spotId, result.SpotId);
        Assert.Equal("Piha", result.Name);
        Assert.Equal(WaveSize.WaistHigh, result.CurrentWaveSize);
        Assert.Single(await db.Favorites.ToListAsync());
    }

    [Fact]
    public async Task AddAsync_is_idempotent_when_already_favorited()
    {
        using var db = CreateDb();
        var spotId = Guid.CreateVersion7();
        db.SurfSpots.Add(MakeSpot(spotId));
        await db.SaveChangesAsync();

        var svc = new FavoritesService(db);
        await svc.AddAsync(UserId, spotId);
        await svc.AddAsync(UserId, spotId);

        Assert.Single(await db.Favorites.ToListAsync());
    }

    [Fact]
    public async Task GetAsync_returns_favorites_ordered_newest_first()
    {
        using var db = CreateDb();
        var spotId1 = Guid.CreateVersion7();
        var spotId2 = Guid.CreateVersion7();
        db.SurfSpots.AddRange(MakeSpot(spotId1, "Piha"), MakeSpot(spotId2, "Muriwai"));
        db.Favorites.AddRange(
            new FavoriteEntity { Id = Guid.CreateVersion7(), UserId = UserId, SpotId = spotId1, CreatedAt = DateTime.UtcNow.AddMinutes(-5), User = null!, Spot = null! },
            new FavoriteEntity { Id = Guid.CreateVersion7(), UserId = UserId, SpotId = spotId2, CreatedAt = DateTime.UtcNow, User = null!, Spot = null! }
        );
        await db.SaveChangesAsync();

        var result = await new FavoritesService(db).GetAsync(UserId);

        Assert.Equal(2, result.Count);
        Assert.Equal("Muriwai", result[0].Name); // newest first
        Assert.Equal("Piha", result[1].Name);
    }

    [Fact]
    public async Task GetAsync_only_returns_favorites_for_the_requesting_user()
    {
        using var db = CreateDb();
        var spotId = Guid.CreateVersion7();
        db.SurfSpots.Add(MakeSpot(spotId));
        db.Favorites.Add(new FavoriteEntity { Id = Guid.CreateVersion7(), UserId = Guid.CreateVersion7(), SpotId = spotId, CreatedAt = DateTime.UtcNow, User = null!, Spot = null! });
        await db.SaveChangesAsync();

        var result = await new FavoritesService(db).GetAsync(UserId);

        Assert.Empty(result);
    }

    [Fact]
    public async Task RemoveAsync_returns_false_when_not_favorited()
    {
        using var db = CreateDb();
        var result = await new FavoritesService(db).RemoveAsync(UserId, Guid.CreateVersion7());
        Assert.False(result);
    }

    [Fact]
    public async Task RemoveAsync_deletes_favorite_and_returns_true()
    {
        using var db = CreateDb();
        var spotId = Guid.CreateVersion7();
        db.SurfSpots.Add(MakeSpot(spotId));
        await db.SaveChangesAsync();

        var svc = new FavoritesService(db);
        await svc.AddAsync(UserId, spotId);

        var removed = await svc.RemoveAsync(UserId, spotId);

        Assert.True(removed);
        Assert.Empty(await db.Favorites.ToListAsync());
    }
}
