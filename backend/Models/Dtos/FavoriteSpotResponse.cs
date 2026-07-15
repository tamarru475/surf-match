using Backend.Models.Enums;

namespace Backend.Models.Dtos;

public record FavoriteSpotResponse(
    Guid SpotId,
    string Name,
    Region Region,
    WaveType WaveType,
    SkillLevel MinSkillLevel,
    CrowdLevel TypicalCrowd,
    IReadOnlyList<Facility> Facilities,
    string Description,
    DateTime FavoritedAt
);
