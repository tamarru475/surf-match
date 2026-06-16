using Backend.Data;
using Backend.Models;
using Backend.Models.Enums;

namespace Backend.Services;

public static class RecommendationEngine
{
    public static RecommendationResponse GetRecommendations(UserPreferences prefs)
    {
        var spots = Filter(SurfSpotCatalog.All, prefs);
        var ranked = Rank(spots, prefs);

        return new RecommendationResponse
        {
            Preferences = prefs,
            Recommendations = ranked
        };
    }

    // ── Hard filters ─────────────────────────────────────────────────────────
    // Applied in order. Skill is always enforced; the rest only apply if the
    // user set that preference.

    private static IEnumerable<SurfSpot> Filter(IEnumerable<SurfSpot> spots, UserPreferences prefs)
    {
        // Always: don't show spots beyond the user's skill level.
        // TODO: in future, a spot's effective skill level will vary with CurrentWaveSize
        //       (e.g. a normally-intermediate break becomes advanced at double overhead).
        spots = spots.Where(s => s.MinSkillLevel <= prefs.SkillLevel);

        if (prefs.PreferredRegion.HasValue)
            spots = spots.Where(s => s.Region == prefs.PreferredRegion.Value);

        if (prefs.PreferredWaveTypes.Count > 0)
            spots = spots.Where(s => prefs.PreferredWaveTypes.Contains(s.WaveType));

        if (prefs.PreferredWaveSizes.Count > 0)
            spots = spots.Where(s => prefs.PreferredWaveSizes.Contains(s.CurrentWaveSize));

        return spots;
    }

    // ── Soft ranking ─────────────────────────────────────────────────────────
    // Board types, crowd, and facilities are judgment calls.
    // Spots that don't fit well are ranked lower and flagged with a note,
    // but never excluded.

    private static List<SpotRecommendation> Rank(IEnumerable<SurfSpot> spots, UserPreferences prefs)
    {
        return spots
            .Select(spot => BuildRecommendation(spot, prefs))
            .OrderByDescending(r => r.Score)
            .ToList();
    }

    private static SpotRecommendation BuildRecommendation(SurfSpot spot, UserPreferences prefs)
    {
        var breakdown = new ScoreBreakdown
        {
            BoardMatch    = ScoreBoard(spot, prefs),
            CrowdMatch    = ScoreCrowd(spot, prefs),
            FacilityMatch = ScoreFacilities(spot, prefs),

            SkillMatch    = 0,
            RegionMatch   = 0,
            WaveTypeMatch = 0,
            WaveSizeMatch = 0
        };

        return new SpotRecommendation
        {
            SpotId        = spot.Id,
            Name          = spot.Name,
            Region        = spot.Region,
            WaveType      = spot.WaveType,
            MinSkillLevel = spot.MinSkillLevel,
            TypicalCrowd  = spot.TypicalCrowd,
            Facilities      = spot.Facilities,
            CurrentWaveSize = spot.CurrentWaveSize,
            Description     = spot.Description,
            Score       = breakdown.BoardMatch + breakdown.CrowdMatch + breakdown.FacilityMatch,
            Summary     = BuildNotes(spot, prefs, breakdown),
            Breakdown   = breakdown
        };
    }

    // Any one of the user's boards matching the spot is a hit.
    // Empty BoardTypes means no preference — neutral, not penalised.
    private static int ScoreBoard(SurfSpot spot, UserPreferences prefs)
    {
        if (prefs.BoardTypes.Count == 0) return 0;
        return prefs.BoardTypes.Any(b => spot.SuitableBoardTypes.Contains(b)) ? 20 : 0;
    }

    private static int ScoreCrowd(SurfSpot spot, UserPreferences prefs)
    {
        var busierBy = (int)spot.TypicalCrowd - (int)prefs.CrowdTolerance;
        if (busierBy <= 0) return 20; // at or below tolerance
        if (busierBy == 1) return 8;  // one level over — still acceptable
        return 0;                     // too crowded
    }

    private static int ScoreFacilities(SurfSpot spot, UserPreferences prefs)
    {
        if (!prefs.CaresAboutFacilities) return 0;
        return prefs.PreferredFacilities.Count(f => spot.Facilities.Contains(f));
    }

    // Plain-language notes about soft mismatches — shown alongside the result.
    private static string BuildNotes(SurfSpot spot, UserPreferences prefs, ScoreBreakdown breakdown)
    {
        var notes = new List<string>();

        if (prefs.BoardTypes.Count > 0 && breakdown.BoardMatch == 0)
            notes.Add("none of your boards are ideal for this spot");

        if ((int)spot.TypicalCrowd > (int)prefs.CrowdTolerance)
            notes.Add($"typically {spot.TypicalCrowd.ToString().ToLower()} — busier than your preference");

        return notes.Count == 0
            ? "Good match."
            : string.Join("; ", notes) + ".";
    }
}
