namespace Backend.Models.Dtos;

public record UpdateProfileRequest(
    string? DisplayName,
    string? Location,
    string? Bio,
    string? InstagramHandle,
    string? TikTokHandle
);
