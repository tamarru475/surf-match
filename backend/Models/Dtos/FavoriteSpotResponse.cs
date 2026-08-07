using Backend.Models.Enums;

namespace Backend.Models.Dtos;

public record FavoriteSpotResponse(
    Guid SpotId,
    string Name,
    Region Region,
    WaveType WaveType,
    SkillLevel MinSkillLevel,
    CrowdLevel TypicalCrowd,
    WaveSize CurrentWaveSize,
    IReadOnlyList<Facility> Facilities,
    string Description,
    DateTime FavoritedAt
);
