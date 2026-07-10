namespace Backend.Models.Dtos;

public record UpdateProfileRequest(
    string? DisplayName,
    string? Bio,
    string? InstagramHandle,
    string? TikTokHandle
);
