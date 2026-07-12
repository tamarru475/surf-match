using Backend.Database;
using Backend.Models.Dtos;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Tests;

public class ProfileServiceTests
{
    private static AppDbContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task GetOrCreate_creates_user_on_first_call()
    {
        await using var db = CreateDb();
        var svc = new ProfileService(db);
        var id = Guid.NewGuid();

        var user = await svc.GetOrCreateAsync(id, "surfer@example.com");

        Assert.Equal(id, user.Id);
        Assert.Equal("surfer@example.com", user.Email);
        Assert.Equal(1, await db.Users.CountAsync());
    }

    [Fact]
    public async Task GetOrCreate_returns_existing_user_without_duplicate()
    {
        await using var db = CreateDb();
        var svc = new ProfileService(db);
        var id = Guid.NewGuid();

        await svc.GetOrCreateAsync(id, "surfer@example.com");
        var second = await svc.GetOrCreateAsync(id, "surfer@example.com");

        Assert.Equal(id, second.Id);
        Assert.Equal(1, await db.Users.CountAsync());
    }

    [Fact]
    public async Task Update_patches_all_profile_fields()
    {
        await using var db = CreateDb();
        var svc = new ProfileService(db);
        var id = Guid.NewGuid();
        await svc.GetOrCreateAsync(id, "surfer@example.com");

        var req = new UpdateProfileRequest("Tamar", "Raglan, NZ", "Loves big waves", "tamar_surfs", "tamar_surfs");
        var updated = await svc.UpdateAsync(id, req);

        Assert.NotNull(updated);
        Assert.Equal("Tamar", updated.DisplayName);
        Assert.Equal("Loves big waves", updated.Bio);
        Assert.Equal("tamar_surfs", updated.InstagramHandle);
        Assert.Equal("tamar_surfs", updated.TikTokHandle);
    }

    [Fact]
    public async Task Update_clears_optional_fields_when_null_is_passed()
    {
        await using var db = CreateDb();
        var svc = new ProfileService(db);
        var id = Guid.NewGuid();
        await svc.GetOrCreateAsync(id, "surfer@example.com");
        await svc.UpdateAsync(id, new UpdateProfileRequest("Tamar", "Raglan, NZ", "Bio", "ig", "tt"));

        var updated = await svc.UpdateAsync(id, new UpdateProfileRequest(null, null, null, null, null));

        Assert.NotNull(updated);
        Assert.Null(updated.DisplayName);
        Assert.Null(updated.Bio);
    }

    [Fact]
    public async Task Update_returns_null_for_unknown_user()
    {
        await using var db = CreateDb();
        var svc = new ProfileService(db);

        var result = await svc.UpdateAsync(Guid.NewGuid(), new UpdateProfileRequest(null, null, null, null, null));

        Assert.Null(result);
    }
}
