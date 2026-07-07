namespace Backend.Database.Entities;

public class SurfSessionEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SpotId { get; set; }
    public DateTime SurfedAt { get; set; }
    public DateTime CreatedAt { get; set; }

    public UserEntity User { get; set; } = null!;
    public SurfSpotEntity Spot { get; set; } = null!;
}
