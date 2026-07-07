namespace Backend.Database.Entities;

public class SurfSpotEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Region { get; set; } = "";
    public string WaveType { get; set; } = "";
    public string MinSkillLevel { get; set; } = "";
    public List<string> SuitableBoardTypes { get; set; } = [];
    public List<string> Facilities { get; set; } = [];
    public string TypicalCrowd { get; set; } = "";
    public string MinWaveSize { get; set; } = "";
    public string MaxWaveSize { get; set; } = "";
    public string CurrentWaveSize { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime CreatedAt { get; set; }

    public ICollection<FavoriteEntity> Favorites { get; set; } = [];
    public ICollection<SurfSessionEntity> SurfSessions { get; set; } = [];
}
