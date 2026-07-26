using Backend.Database;
using Backend.Database.Entities;
using Backend.Models.Dtos;
using Backend.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class SurfSessionService(AppDbContext db)
{
    public async Task<SurfSessionResponse?> LogAsync(Guid userId, Guid spotId)
    {
        var spot = await db.SurfSpots.FindAsync(spotId);
        if (spot is null) return null;

        var session = new SurfSessionEntity
        {
            Id        = Guid.CreateVersion7(),
            UserId    = userId,
            SpotId    = spotId,
            SurfedAt  = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            Spot      = spot,
            User      = null!, // FK-only insert; EF Core populates on load
        };
        db.SurfSessions.Add(session);
        await db.SaveChangesAsync();
        return ToResponse(session, spot);
    }

    public async Task<SurfSessionResponse?> GetLastAsync(Guid userId)
    {
        var session = await db.SurfSessions
            .Where(s => s.UserId == userId)
            .Include(s => s.Spot)
            .OrderByDescending(s => s.SurfedAt)
            .FirstOrDefaultAsync();

        return session is null ? null : ToResponse(session, session.Spot);
    }

    private static SurfSessionResponse ToResponse(SurfSessionEntity s, SurfSpotEntity sp) => new(
        SessionId:       s.Id,
        SpotId:          sp.Id,
        SpotName:        sp.Name,
        Region:          Enum.Parse<Region>(sp.Region),
        WaveType:        Enum.Parse<WaveType>(sp.WaveType),
        CurrentWaveSize: Enum.Parse<WaveSize>(sp.CurrentWaveSize),
        SurfedAt:        s.SurfedAt
    );
}
