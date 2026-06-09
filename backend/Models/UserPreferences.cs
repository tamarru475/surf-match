using Backend.Models.Enums;

namespace Backend.Models;

public class UserPreferences
{
    public SkillLevel SkillLevel { get; init; }
    public BoardType BoardType { get; init; }
    public CrowdLevel CrowdTolerance { get; init; }

    public Region? PreferredRegion { get; init; }
    public WaveType? PreferredWaveType { get; init; }
    public IReadOnlyList<WaveSize> PreferredWaveSizes { get; init; } = [];
    public IReadOnlyList<Facility> PreferredFacilities { get; init; } = [];

    // Only ticked PreferredFacilities affect scoring,
    // and spots are never excluded because of facilities (empty results should not happen here).
    public bool CaresAboutFacilities => PreferredFacilities.Count > 0;
}
