using Backend.Models.Enums;

namespace Backend.Models.Dtos;

public record SurfSessionResponse(
    Guid SessionId,
    Guid SpotId,
    string SpotName,
    Region Region,
    WaveType WaveType,
    WaveSize CurrentWaveSize,
    DateTime SurfedAt
);
