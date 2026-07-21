using Backend.Services;
using Microsoft.AspNetCore.Http;

namespace Backend.Tests;

public class AvatarServiceTests
{
    // ── Fake IFormFile ────────────────────────────────────────────────────────

    private static IFormFile FakeFile(long length, string contentType, string fileName = "photo.jpg")
    {
        var bytes = new byte[length];
        var stream = new MemoryStream(bytes);
        return new FormFile(stream, 0, length, "file", fileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = contentType,
        };
    }

    // ── Validate ──────────────────────────────────────────────────────────────

    [Fact]
    public void Validate_returns_error_for_empty_file()
    {
        var file = FakeFile(0, "image/jpeg");
        var (valid, error) = AvatarService.Validate(file);
        Assert.False(valid);
        Assert.Contains("No file", error);
    }

    [Fact]
    public void Validate_returns_error_when_file_exceeds_5mb()
    {
        var file = FakeFile(6 * 1024 * 1024, "image/jpeg");
        var (valid, error) = AvatarService.Validate(file);
        Assert.False(valid);
        Assert.Contains("too large", error);
    }

    [Theory]
    [InlineData("image/gif")]
    [InlineData("image/heic")]
    [InlineData("application/pdf")]
    public void Validate_returns_error_for_unsupported_content_type(string contentType)
    {
        var file = FakeFile(1024, contentType);
        var (valid, error) = AvatarService.Validate(file);
        Assert.False(valid);
        Assert.Contains(contentType, error);
    }

    [Theory]
    [InlineData("image/jpeg")]
    [InlineData("image/jpg")]
    [InlineData("image/png")]
    [InlineData("image/webp")]
    public void Validate_accepts_supported_image_types(string contentType)
    {
        var file = FakeFile(1024, contentType);
        var (valid, error) = AvatarService.Validate(file);
        Assert.True(valid);
        Assert.Null(error);
    }

    [Fact]
    public void Validate_accepts_file_exactly_at_5mb_limit()
    {
        var file = FakeFile(5 * 1024 * 1024, "image/png");
        var (valid, _) = AvatarService.Validate(file);
        Assert.True(valid);
    }
}
