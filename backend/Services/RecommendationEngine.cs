using Backend.Data;
using Backend.Models;
using Backend.Models.Enums;

namespace Backend.Services;

public static class RecommendationEngine
{
    public static RecommendationResponse GetRecommendations(UserPreferences prefs)
    {
        var (spots, warnings) = FilterWithFallback(SurfSpotCatalog.All, prefs);
        var ranked = Rank(spots, prefs);

        return new RecommendationResponse
        {
            Preferences = prefs,
            Recommendations = ranked,
            Warnings = warnings
        };
    }

    // ── Hard filters ─────────────────────────────────────────────────────────
    // Skill is always enforced and never relaxed — recommending a spot above
    // the user's ability is a safety issue, not a UX one. Region, wave type,
    // and wave size are dropped one at a time, least-essential first, only if
    // the stricter combination would otherwise return zero spots. This is what
    // guarantees the response is never empty.

    private static (List<SurfSpot> Spots, List<string> Warnings) FilterWithFallback(
        IEnumerable<SurfSpot> allSpots, UserPreferences prefs)
    {
        // No spot in the catalog has a MinSkillLevel below Beginner, so clamp
        // NewToSurfing up to Beginner here rather than returning zero results.
        // TODO: in future, a spot's effective skill level will vary with CurrentWaveSize
        //       (e.g. a normally-intermediate break becomes advanced at double overhead).
        var effectiveSkill = prefs.SkillLevel < SkillLevel.Beginner ? SkillLevel.Beginner : prefs.SkillLevel;
        var bySkill = allSpots.Where(s => s.MinSkillLevel <= effectiveSkill).ToList();

        var relaxWaveSize = false;
        var relaxWaveType = false;
        var relaxRegion = false;

        List<SurfSpot> Apply()
        {
            var spots = bySkill.AsEnumerable();

            if (!relaxRegion && prefs.PreferredRegion.HasValue)
                spots = spots.Where(s => s.Region == prefs.PreferredRegion.Value);

            if (!relaxWaveType && prefs.PreferredWaveTypes.Count > 0)
                spots = spots.Where(s => prefs.PreferredWaveTypes.Contains(s.WaveType));

            if (!relaxWaveSize && prefs.PreferredWaveSizes.Count > 0)
                spots = spots.Where(s => prefs.PreferredWaveSizes.Contains(s.CurrentWaveSize));

            return spots.ToList();
        }

        var spots = Apply();
        var warnings = new List<string>();

        if (spots.Count == 0 && prefs.PreferredWaveSizes.Count > 0)
        {
            relaxWaveSize = true;
            warnings.Add("Today's wave size didn't match anything else you picked, so we're showing all sizes.");
            spots = Apply();
        }

        if (spots.Count == 0 && prefs.PreferredWaveTypes.Count > 0)
        {
            relaxWaveType = true;
            warnings.Add("Your preferred wave type didn't match anything else you picked, so we're showing all wave types.");
            spots = Apply();
        }

        if (spots.Count == 0 && prefs.PreferredRegion.HasValue)
        {
            relaxRegion = true;
            warnings.Add($"No spots in {prefs.PreferredRegion.Value} matched your skill level, so we're showing spots from other regions too.");
            spots = Apply();
        }

        // bySkill always contains at least the catalog's Beginner spots, so
        // this is guaranteed non-empty once region/type/size are all relaxed.
        return (spots, warnings);
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
            Notes       = BuildNotes(spot, prefs, breakdown),
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

    // Plain-language notes about soft mismatches and current conditions —
    // shown alongside the result, one note per item rather than one joined
    // sentence, so the frontend can list them individually.
    private static List<string> BuildNotes(SurfSpot spot, UserPreferences prefs, ScoreBreakdown breakdown)
    {
        var notes = new List<string>();

        if (prefs.BoardTypes.Count > 0 && breakdown.BoardMatch == 0)
            notes.Add("None of your boards are ideal for this spot.");

        if ((int)spot.TypicalCrowd > (int)prefs.CrowdTolerance)
            notes.Add($"Typically {spot.TypicalCrowd.ToString().ToLower()} — busier than your preference.");

        // TODO: once forecast data is wired up, replace this static threshold
        // with real conditions, e.g. "strong onshore" or "strong rips".
        if (spot.CurrentWaveSize >= WaveSize.HeadHigh)
            notes.Add("Big conditions today.");

        return notes;
    }
}
