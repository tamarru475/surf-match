using Backend.Models.Enums;

namespace Backend.Models;

public class SpotRecommendation
{
    public Guid SpotId { get; init; }
    public string Name { get; init; } = "";
    public Region Region { get; init; }
    public WaveType WaveType { get; init; }
    public IReadOnlyList<Facility> Facilities { get; init; } = [];
    public string Description { get; init; } = "";

    public int Score { get; init; }
    public string Summary { get; init; } = "";
    public ScoreBreakdown Breakdown { get; init; } = new();
}

public class ScoreBreakdown
{
    public int SkillMatch { get; init; }
    public int BoardMatch { get; init; }
    public int CrowdMatch { get; init; }
    public int RegionMatch { get; init; }
    public int WaveTypeMatch { get; init; }
    public int WaveSizeMatch { get; init; }
    public int FacilityMatch { get; init; }
}

public class RecommendationResponse
{
    public UserPreferences Preferences { get; init; } = new();
    public IReadOnlyList<SpotRecommendation> Recommendations { get; init; } = [];
}
