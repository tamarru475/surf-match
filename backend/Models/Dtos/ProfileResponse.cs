namespace Backend.Models.Dtos;

public record ProfileResponse(
    Guid Id,
    string Email,
    string DisplayName,
    string AvatarUrl,
    string Location,
    string Bio,
    string InstagramHandle,
    string TikTokHandle
);
