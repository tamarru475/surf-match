using Backend.Models.Enums;

namespace Backend.Models;

public class UserPreferences
{
    public SkillLevel SkillLevel { get; init; }
    public CrowdLevel CrowdTolerance { get; init; }

    public Region? PreferredRegion { get; init; }

    // Multi-select — empty list means no preference (not filtered / not scored)
    public IReadOnlyList<BoardType> BoardTypes { get; init; } = [];
    public IReadOnlyList<WaveType> PreferredWaveTypes { get; init; } = [];
    public IReadOnlyList<WaveSize> PreferredWaveSizes { get; init; } = [];
    public IReadOnlyList<Facility> PreferredFacilities { get; init; } = [];

    public bool CaresAboutFacilities => PreferredFacilities.Count > 0;
}
