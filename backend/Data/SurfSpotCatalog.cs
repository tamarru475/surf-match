using Backend.Models;
using Backend.Models.Enums;

namespace Backend.Data;

public static class SurfSpotCatalog
{
    public static readonly IReadOnlyList<SurfSpot> All =
    [
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000001"),
            Name = "Ngarunui Beach",
            Region = Region.Waikato,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.Rentals, Facility.Lifeguard],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "Raglan's long sandy beach break. Consistent, gentle waves and lifeguard patrol make it the go-to beginner spot on the West Coast."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000002"),
            Name = "Manu Bay",
            Region = Region.Waikato,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Longboard, BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Busy,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "Raglan's iconic left-hand point break — one of the longest in the Southern Hemisphere. A bucket-list wave that draws surfers from around the world."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000003"),
            Name = "Mount Maunganui",
            Region = Region.BayOfPlenty,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Fish, BoardType.Shortboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub, Facility.Rentals, Facility.Lifeguard],
            TypicalCrowd = CrowdLevel.Busy,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "The Mount's main beach is a long, approachable beach break with excellent facilities. A great all-rounder spot suitable for every level."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000004"),
            Name = "Gisborne Town",
            Region = Region.Gisborne,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub, Facility.Rentals, Facility.Lifeguard],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "Waikanae Beach sits right in town and offers mellow, learner-friendly waves backed by full beach facilities."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000005"),
            Name = "Makorori Point",
            Region = Region.Gisborne,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Longboard, BoardType.Fish, BoardType.Shortboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A cobblestone right-hander just north of Gisborne. Quieter than the town beach with fun point break walls on a good swell."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000006"),
            Name = "Scarborough",
            Region = Region.Christchurch,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Longboard],
            Facilities = [Facility.Bathrooms, Facility.Showers],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "Tucked beside Sumner, Scarborough picks up solid South Island swells and offers punchy beach break waves in a scenic setting."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000007"),
            Name = "Mangawhai Heads",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "A reliable North Auckland beach break that delivers consistent surf and is usually less hectic than the city breaks."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000008"),
            Name = "Orewa Beach",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.Lifeguard],
            TypicalCrowd = CrowdLevel.Busy,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.WaistHigh,
            CurrentWaveSize = WaveSize.AnkleHigh,
            Description = "A long, sheltered beach just north of Auckland city with gentle, rolling waves — ideal for beginners and longboarders."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000009"),
            Name = "Omaha",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A popular holiday beach north of Auckland that picks up decent swells and serves up fun beach break peaks across its length."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000010"),
            Name = "Te Arai",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Longboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A tucked-away beach inside a conservation area north of Mangawhai. Worth the walk in for quality, uncrowded waves."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000011"),
            Name = "Forestry",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "An Auckland beach break that rewards those who make the effort with uncrowded, quality waves away from the main beaches."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000012"),
            Name = "Muriwai",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub, Facility.Lifeguard],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "Auckland's wild black-sand West Coast beach. Powerful and consistent with strong rips — rewarding for surfers with solid ocean awareness."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000013"),
            Name = "Piha",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub, Facility.Lifeguard],
            TypicalCrowd = CrowdLevel.Busy,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "Auckland's most famous surf beach — powerful, dramatic, and stunning. Heavy rips demand solid ocean experience before paddling out."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000014"),
            Name = "Tawharanui",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Longboard, BoardType.Funboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms, Facility.Campground],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "Inside a protected regional park on the Tawharanui Peninsula. A peaceful beach break with low crowds and a campground for an overnight trip."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000015"),
            Name = "Waihi Beach",
            Region = Region.BayOfPlenty,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub, Facility.Lifeguard],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "A long, welcoming Bay of Plenty beach break. Consistent and forgiving — good for beginners and longboarders making the most of summer."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000016"),
            Name = "Pauanui",
            Region = Region.Coromandel,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms, Facility.Showers],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A pretty Coromandel beach break with fun, manageable waves — popular with holidaying families and surfers looking for a chill session."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000017"),
            Name = "Whangamata",
            Region = Region.Coromandel,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub, Facility.Lifeguard],
            TypicalCrowd = CrowdLevel.Busy,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "One of the Coromandel's most popular surf towns. Peaks fire up and down the beach and it's at its best during an easterly swell."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000018"),
            Name = "Waipu Cove",
            Region = Region.Northland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Longboard, BoardType.Funboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms, Facility.Campground],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.WaistHigh,
            CurrentWaveSize = WaveSize.AnkleHigh,
            Description = "A sheltered Northland cove with mellow, beginner-friendly waves and a relaxed holiday vibe."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000019"),
            Name = "Shipwreck Bay",
            Region = Region.Northland,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Advanced,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.DoubleOverhead,
            Description = "One of New Zealand's longest left-hand point breaks, near Ahipara at the foot of Ninety Mile Beach. Remote and raw — a reward for the committed."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000020"),
            Name = "Bethells Beach",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "A dramatic black-sand beach tucked in a valley west of Auckland. Powerful beach break that rewards those who respect its conditions."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000021"),
            Name = "Sandy Bay",
            Region = Region.Northland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A hidden gem near Tutukaka in Northland. Sandy bottom beach break that rarely gets crowded — worth tracking down."
        },

        // ── Taranaki ─────────────────────────────────────────────────────────

        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000022"),
            Name = "Stent Road",
            Region = Region.Taranaki,
            WaveType = WaveType.ReefBreak,
            MinSkillLevel = SkillLevel.Advanced,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A long, walling left-hand reef break near Oakura. One of Taranaki's most consistent and rewarding waves — best at solid swell with a light offshore."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000023"),
            Name = "Kumara Patch",
            Region = Region.Taranaki,
            WaveType = WaveType.ReefBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "A mellow reef break in Taranaki that turns on when other spots are too big. A local favourite that stays quiet even on good days."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000024"),
            Name = "Back Beach",
            Region = Region.Taranaki,
            WaveType = WaveType.ReefBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "The main surf break in New Plymouth, breaking over a mix of reef and sand beneath the volcanic headland. Punchy and powerful when it lines up."
        },

        // ── Auckland reef breaks ──────────────────────────────────────────────

        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000025"),
            Name = "Takapuna Reef",
            Region = Region.Auckland,
            WaveType = WaveType.ReefBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "A reef break sitting just off Takapuna Beach on Auckland's North Shore. Can produce surprisingly good waves when the swell direction lines up."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000026"),
            Name = "Daniels Reef",
            Region = Region.Auckland,
            WaveType = WaveType.ReefBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A lesser-known Auckland reef that rewards those in the know with uncrowded, hollow waves when conditions align. Worth checking on a small easterly swell."
        },

        // ── Gisborne ──────────────────────────────────────────────────────────

        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000027"),
            Name = "Wainui Beach",
            Region = Region.Gisborne,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Fish, BoardType.Shortboard],
            Facilities = [Facility.Bathrooms, Facility.Lifeguard],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "A long sandy beach just north of Gisborne city with consistent beach break peaks. Popular with locals and a reliable option when the easterly swells arrive."
        },

        // ── Kaikoura ──────────────────────────────────────────────────────────

        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000028"),
            Name = "Meatworks",
            Region = Region.Kaikoura,
            WaveType = WaveType.ReefBreak,
            MinSkillLevel = SkillLevel.Advanced,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A powerful left-hand reef break tucked below the Kaikoura mountains. Named after the old meatworks nearby — raw, heavy, and stunning when it's firing."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000029"),
            Name = "Mangamaunu",
            Region = Region.Kaikoura,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Longboard, BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "One of New Zealand's longest right-hand point breaks, walling for hundreds of metres along the Kaikoura coastline. A remote gem that makes the drive from Christchurch very worthwhile."
        },

        // ── Christchurch (additional) ─────────────────────────────────────────

        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000030"),
            Name = "Taylor's Mistake",
            Region = Region.Christchurch,
            WaveType = WaveType.ReefBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Longboard],
            Facilities = [],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A hidden bay east of Sumner with rocky headland rights that reward surfers willing to make the hike from the car park. One of Canterbury's most scenic and consistent breaks."
        },

        // ── Bay of Plenty (additional) ────────────────────────────────────────

        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000031"),
            Name = "Ohope Beach",
            Region = Region.BayOfPlenty,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Shortboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.Lifeguard, Facility.Campground],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.WaistHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "A long, sandy stretch east of Whakatane with mellow beach break peaks and plenty of space. One of the Bay of Plenty's quietest surf beaches — ideal for beginners wanting room to learn."
        },

        // ── Coromandel (additional) ───────────────────────────────────────────

        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000032"),
            Name = "Tairua",
            Region = Region.Coromandel,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Shortboard],
            Facilities = [Facility.Bathrooms, Facility.SurfClub],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.WaistHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "A sheltered harbour-mouth beach break on the Coromandel's east coast that picks up east and northeast swells well. A reliable option when the west side is flat."
        },

        // ── Wellington ────────────────────────────────────────────────────────

        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000033"),
            Name = "Lyall Bay",
            Region = Region.Wellington,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub, Facility.Lifeguard, Facility.Rentals],
            TypicalCrowd = CrowdLevel.Busy,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "Wellington's most accessible surf beach, right next to the airport. Consistent swell from Cook Strait makes it reliable year-round, though it fires best on calm mornings before the afternoon northerly kicks in."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000034"),
            Name = "Castlepoint",
            Region = Region.Wellington,
            WaveType = WaveType.ReefBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms, Facility.Campground],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "A dramatic lighthouse bay on the Wairarapa coast, two hours from Wellington. A reef break that fires with powerful East Coast swells — the remote setting and iconic scenery make the drive very much worth it."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000035"),
            Name = "Makara Beach",
            Region = Region.Wellington,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A raw, wind-exposed beach break on Wellington's rugged west coast. Gets open-ocean swell that rarely reaches Lyall Bay — worth the extra drive when conditions align and the wind is light."
        },

        // ── Otago ─────────────────────────────────────────────────────────────

        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000036"),
            Name = "St Clair Beach",
            Region = Region.Otago,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub, Facility.Lifeguard, Facility.Rentals],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "Dunedin's iconic surf beach at the foot of the Otago Peninsula. Reliable Southern Ocean swells, a surf club that's been running for over a century, and a famous saltwater hot pool right on the beachfront."
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000037"),
            Name = "St Kilda",
            Region = Region.Otago,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Shortboard],
            Facilities = [Facility.Bathrooms, Facility.SurfClub],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "Dunedin's quieter neighbour to St Clair, sharing the same reliable Southern Ocean swells on a long exposed beach with consistent peaks. A good choice when St Clair is too busy."
        }
    ];
}
