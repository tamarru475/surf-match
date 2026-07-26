namespace Backend.Database.Entities;

public class UserPreferencesEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string SkillLevel { get; set; } = "";
    public string CrowdTolerance { get; set; } = "";
    public string PreferredRegion { get; set; } = "";
    public List<string> BoardTypes { get; set; } = [];
    public List<string> PreferredWaveTypes { get; set; } = [];
    public List<string> PreferredWaveSizes { get; set; } = [];
    public List<string> PreferredFacilities { get; set; } = [];
    public DateTime UpdatedAt { get; set; }

    public required UserEntity User { get; set; }
}
