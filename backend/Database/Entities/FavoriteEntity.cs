namespace Backend.Database.Entities;

public class FavoriteEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SpotId { get; set; }
    public DateTime CreatedAt { get; set; }

    public required UserEntity User { get; set; }
    public required SurfSpotEntity Spot { get; set; }
}
