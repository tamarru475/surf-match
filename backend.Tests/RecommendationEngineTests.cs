using Backend.Models;
using Backend.Models.Enums;
using Backend.Services;

namespace Backend.Tests;

public class RecommendationEngineTests
{
    // ── Skill filter ──────────────────────────────────────────────────────────

    [Fact]
    public void Beginner_does_not_see_intermediate_or_advanced_spots()
    {
        var result = Recommend(skill: SkillLevel.Beginner);

        Assert.All(result, r =>
        {
            var spot = SpotByName(r.Name);
            Assert.True(spot.MinSkillLevel <= SkillLevel.Beginner);
        });
    }

    [Fact]
    public void New_to_surfing_sees_beginner_spots_instead_of_zero_results()
    {
        var result = Recommend(skill: SkillLevel.NewToSurfing);

        var beginnerSpotNames = Backend.Data.SurfSpotCatalog.All
            .Where(s => s.MinSkillLevel == SkillLevel.Beginner)
            .Select(s => s.Name)
            .ToHashSet();

        var returnedNames = result.Select(r => r.Name).ToHashSet();
        Assert.True(beginnerSpotNames.SetEquals(returnedNames),
            "New to surfing should be clamped to see exactly the beginner spots");
    }

    [Fact]
    public void Intermediate_sees_beginner_spots()
    {
        var result = Recommend(skill: SkillLevel.Intermediate);

        var beginnerSpotNames = Backend.Data.SurfSpotCatalog.All
            .Where(s => s.MinSkillLevel == SkillLevel.Beginner)
            .Select(s => s.Name)
            .ToHashSet();

        var returnedNames = result.Select(r => r.Name).ToHashSet();
        Assert.True(beginnerSpotNames.IsSubsetOf(returnedNames),
            "Intermediate surfer should see all beginner spots");
    }

    [Fact]
    public void Expert_sees_all_spots()
    {
        var result = Recommend(skill: SkillLevel.Expert);

        Assert.Equal(Backend.Data.SurfSpotCatalog.All.Count, result.Count);
    }

    // ── Region filter ─────────────────────────────────────────────────────────

    [Fact]
    public void Region_filter_excludes_other_regions()
    {
        var result = Recommend(skill: SkillLevel.Expert, region: Region.Waikato);

        Assert.All(result, r => Assert.Equal(Region.Waikato, r.Region));
        Assert.NotEmpty(result);
    }

    [Fact]
    public void No_region_filter_returns_spots_from_multiple_regions()
    {
        var result = Recommend(skill: SkillLevel.Expert);

        var regions = result.Select(r => r.Region).Distinct().ToList();
        Assert.True(regions.Count > 1);
    }

    // ── Wave type filter ──────────────────────────────────────────────────────

    [Fact]
    public void Wave_type_filter_excludes_non_matching_breaks()
    {
        var result = Recommend(skill: SkillLevel.Expert, waveTypes: [WaveType.PointBreak]);

        Assert.All(result, r => Assert.Equal(WaveType.PointBreak, r.WaveType));
        Assert.NotEmpty(result);
    }

    [Fact]
    public void Multiple_wave_types_returns_all_matching_breaks()
    {
        var result = Recommend(skill: SkillLevel.Expert,
            waveTypes: [WaveType.BeachBreak, WaveType.PointBreak]);

        var types = result.Select(r => r.WaveType).Distinct().ToList();
        Assert.Contains(WaveType.BeachBreak, types);
        Assert.Contains(WaveType.PointBreak, types);
    }

    [Fact]
    public void Empty_wave_type_preference_returns_all_break_types()
    {
        var result = Recommend(skill: SkillLevel.Expert, waveTypes: []);

        var types = result.Select(r => r.WaveType).Distinct().ToList();
        Assert.True(types.Count > 1);
    }

    // ── Wave size filter ──────────────────────────────────────────────────────

    [Fact]
    public void Wave_size_filter_only_returns_spots_at_current_size()
    {
        var result = Recommend(skill: SkillLevel.Expert, waveSizes: [WaveSize.WaistHigh]);

        Assert.All(result, r =>
            Assert.Equal(WaveSize.WaistHigh, SpotByName(r.Name).CurrentWaveSize));
    }

    [Fact]
    public void Multiple_wave_sizes_returns_spots_matching_any()
    {
        var result = Recommend(skill: SkillLevel.Expert,
            waveSizes: [WaveSize.KneeHigh, WaveSize.WaistHigh]);

        Assert.All(result, r =>
        {
            var size = SpotByName(r.Name).CurrentWaveSize;
            Assert.True(size == WaveSize.KneeHigh || size == WaveSize.WaistHigh);
        });
    }

    // ── Soft ranking ──────────────────────────────────────────────────────────

    [Fact]
    public void Results_are_ordered_highest_score_first()
    {
        var result = Recommend(skill: SkillLevel.Expert);

        var scores = result.Select(r => r.Score).ToList();
        Assert.Equal(scores.OrderByDescending(s => s).ToList(), scores);
    }

    [Fact]
    public void Board_match_raises_score()
    {
        var result = Recommend(skill: SkillLevel.Expert, boards: [BoardType.Longboard]);

        var withMatch = result.Where(r => r.Breakdown.BoardMatch > 0).Select(r => r.Score);
        var withoutMatch = result.Where(r => r.Breakdown.BoardMatch == 0).Select(r => r.Score);

        if (withMatch.Any() && withoutMatch.Any())
            Assert.True(withMatch.Min() >= withoutMatch.Max());
    }

    [Fact]
    public void Quiet_spot_scores_higher_than_busy_spot_for_quiet_preference()
    {
        var result = Recommend(skill: SkillLevel.Expert, crowd: CrowdLevel.Quiet);

        var quietScore = result.First(r => r.Breakdown.CrowdMatch == 20).Score;
        var busyScore = result.First(r => r.Breakdown.CrowdMatch == 0).Score;

        Assert.True(quietScore > busyScore);
    }

    [Fact]
    public void Crowd_note_added_when_spot_is_busier_than_tolerance()
    {
        var result = Recommend(skill: SkillLevel.Expert, crowd: CrowdLevel.Quiet);

        var busierThanTolerance = result.Where(r =>
            SpotByName(r.Name).TypicalCrowd > CrowdLevel.Quiet);

        Assert.All(busierThanTolerance, r =>
            Assert.Contains(r.Notes, n => n.Contains("busier than your preference")));
    }

    [Fact]
    public void Board_note_added_when_no_boards_match()
    {
        var result = Recommend(skill: SkillLevel.Expert, boards: [BoardType.Rental]);

        var noMatch = result.Where(r => r.Breakdown.BoardMatch == 0);

        Assert.All(noMatch, r =>
            Assert.Contains(r.Notes, n => n.Contains("None of your boards are ideal")));
    }

    [Fact]
    public void Big_conditions_note_added_for_head_high_or_bigger()
    {
        var result = Recommend(skill: SkillLevel.Expert);

        var big = result.Where(r => r.CurrentWaveSize >= WaveSize.HeadHigh);
        var small = result.Where(r => r.CurrentWaveSize < WaveSize.HeadHigh);

        Assert.NotEmpty(big);
        Assert.All(big, r => Assert.Contains(r.Notes, n => n.Contains("Big conditions today")));
        Assert.All(small, r => Assert.DoesNotContain(r.Notes, n => n.Contains("Big conditions today")));
    }

    [Fact]
    public void Multiple_notes_are_returned_as_separate_items()
    {
        var result = Recommend(skill: SkillLevel.Expert, crowd: CrowdLevel.Quiet, boards: [BoardType.Rental]);

        var manuBay = result.First(r => r.Name == "Manu Bay");

        Assert.Equal(3, manuBay.Notes.Count);
    }

    // ── Never-zero-results fallback ──────────────────────────────────────────

    [Fact]
    public void No_relaxation_needed_returns_no_warnings()
    {
        var response = RecommendFull(skill: SkillLevel.Beginner, region: Region.Auckland);

        Assert.NotEmpty(response.Recommendations);
        Assert.Empty(response.Warnings);
    }

    [Fact]
    public void Wave_size_alone_is_relaxed_when_it_is_the_only_blocker()
    {
        // Beginner + Auckland has 4 spots, but none currently DoubleOverhead.
        var response = RecommendFull(skill: SkillLevel.Beginner, region: Region.Auckland,
            waveSizes: [WaveSize.DoubleOverhead]);

        Assert.NotEmpty(response.Recommendations);
        Assert.All(response.Recommendations, r => Assert.Equal(Region.Auckland, r.Region));
        Assert.Contains(response.Warnings, w => w.Contains("wave size"));
        Assert.DoesNotContain(response.Warnings, w => w.Contains("wave type"));
        Assert.DoesNotContain(response.Warnings, w => w.Contains("Auckland"));
    }

    [Fact]
    public void Wave_size_and_wave_type_are_both_relaxed_when_needed()
    {
        // Beginner + Auckland has no reef breaks at all, so dropping wave size
        // alone isn't enough — wave type must go too.
        var response = RecommendFull(skill: SkillLevel.Beginner, region: Region.Auckland,
            waveTypes: [WaveType.ReefBreak], waveSizes: [WaveSize.DoubleOverhead]);

        Assert.NotEmpty(response.Recommendations);
        Assert.All(response.Recommendations, r => Assert.Equal(Region.Auckland, r.Region));
        Assert.Contains(response.Warnings, w => w.Contains("wave size"));
        Assert.Contains(response.Warnings, w => w.Contains("wave type"));
    }

    [Fact]
    public void Region_is_relaxed_as_a_last_resort_when_skill_alone_would_be_empty()
    {
        // Taranaki has no Beginner-level spots at all.
        var response = RecommendFull(skill: SkillLevel.Beginner, region: Region.Taranaki);

        Assert.NotEmpty(response.Recommendations);
        Assert.Contains(response.Warnings, w => w.Contains("Taranaki"));
        Assert.DoesNotContain(response.Recommendations, r => r.Region == Region.Taranaki);
    }

    // ── Helpers ───────────────────────────────────────────────────────────────

    private static List<SpotRecommendation> Recommend(
        SkillLevel skill = SkillLevel.Intermediate,
        CrowdLevel crowd = CrowdLevel.Moderate,
        Region? region = null,
        IReadOnlyList<BoardType>? boards = null,
        IReadOnlyList<WaveType>? waveTypes = null,
        IReadOnlyList<WaveSize>? waveSizes = null,
        IReadOnlyList<Facility>? facilities = null) =>
        RecommendFull(skill, crowd, region, boards, waveTypes, waveSizes, facilities).Recommendations.ToList();

    private static RecommendationResponse RecommendFull(
        SkillLevel skill = SkillLevel.Intermediate,
        CrowdLevel crowd = CrowdLevel.Moderate,
        Region? region = null,
        IReadOnlyList<BoardType>? boards = null,
        IReadOnlyList<WaveType>? waveTypes = null,
        IReadOnlyList<WaveSize>? waveSizes = null,
        IReadOnlyList<Facility>? facilities = null)
    {
        var prefs = new UserPreferences
        {
            SkillLevel = skill,
            CrowdTolerance = crowd,
            PreferredRegion = region,
            BoardTypes = boards ?? [],
            PreferredWaveTypes = waveTypes ?? [],
            PreferredWaveSizes = waveSizes ?? [],
            PreferredFacilities = facilities ?? []
        };

        return RecommendationEngine.GetRecommendations(prefs);
    }

    private static Backend.Models.SurfSpot SpotByName(string name) =>
        Backend.Data.SurfSpotCatalog.All.Single(s => s.Name == name);
}
