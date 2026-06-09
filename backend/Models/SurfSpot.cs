using Backend.Models.Enums;

namespace Backend.Models;

public class SurfSpot
{
    public Guid Id { get; init; }
    public string Name { get; init; } = "";
    public Region Region { get; init; }
    public WaveType WaveType { get; init; }

    public SkillLevel MinSkillLevel { get; init; }
    public IReadOnlyList<BoardType> SuitableBoardTypes { get; init; } = [];
    public IReadOnlyList<Facility> Facilities { get; init; } = [];

    public CrowdLevel TypicalCrowd { get; init; }
    public WaveSize MinWaveSize { get; init; }
    public WaveSize MaxWaveSize { get; init; }

    public string Description { get; init; } = "";
}
