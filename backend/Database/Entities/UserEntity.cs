namespace Backend.Database.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public string AvatarUrl { get; set; } = "";
    public string Location { get; set; } = "";
    public string Bio { get; set; } = "";
    public string InstagramHandle { get; set; } = "";
    public string TikTokHandle { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public UserPreferencesEntity? Preferences { get; set; }
    public ICollection<FavoriteEntity> Favorites { get; set; } = [];
    public ICollection<SurfSessionEntity> SurfSessions { get; set; } = [];
}
