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
        var updated = await svc.UpdateAsync(id, "surfer@example.com", req);

        Assert.Equal("Tamar", updated.DisplayName);
        Assert.Equal("Loves big waves", updated.Bio);
        Assert.Equal("tamar_surfs", updated.InstagramHandle);
        Assert.Equal("tamar_surfs", updated.TikTokHandle);
    }

    [Fact]
    public async Task Update_clears_optional_fields_when_empty_string_is_passed()
    {
        await using var db = CreateDb();
        var svc = new ProfileService(db);
        var id = Guid.NewGuid();
        await svc.GetOrCreateAsync(id, "surfer@example.com");
        await svc.UpdateAsync(id, "surfer@example.com", new UpdateProfileRequest("Tamar", "Raglan, NZ", "Bio", "ig", "tt"));

        var updated = await svc.UpdateAsync(id, "surfer@example.com", new UpdateProfileRequest("", "", "", "", ""));

        Assert.Equal("", updated.DisplayName);
        Assert.Equal("", updated.Bio);
    }

    [Fact]
    public async Task Update_creates_user_row_when_it_does_not_exist_yet()
    {
        // PUT /me can be called before GET /me in edge cases; UpdateAsync should
        // create the row rather than failing.
        await using var db = CreateDb();
        var svc = new ProfileService(db);
        var id = Guid.NewGuid();

        var updated = await svc.UpdateAsync(id, "surfer@example.com", new UpdateProfileRequest("Tamar", "Auckland", "", "", ""));

        Assert.Equal(id, updated.Id);
        Assert.Equal("Tamar", updated.DisplayName);
        Assert.Equal("Auckland", updated.Location);
        Assert.Equal(1, await db.Users.CountAsync());
    }

    [Fact]
    public async Task UpdateAvatarUrl_persists_url_on_user()
    {
        await using var db = CreateDb();
        var svc = new ProfileService(db);
        var id = Guid.NewGuid();
        await svc.GetOrCreateAsync(id, "surfer@example.com");

        var updated = await svc.UpdateAvatarUrlAsync(id, "https://example.com/avatar.jpg");

        Assert.NotNull(updated);
        Assert.Equal("https://example.com/avatar.jpg", updated.AvatarUrl);
    }

    [Fact]
    public async Task UpdateAvatarUrl_returns_null_for_unknown_user()
    {
        await using var db = CreateDb();
        var svc = new ProfileService(db);

        var result = await svc.UpdateAvatarUrlAsync(Guid.NewGuid(), "https://example.com/avatar.jpg");

        Assert.Null(result);
    }
}
