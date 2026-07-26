using Backend.Models;
using Backend.Models.Enums;

namespace Backend.Data;

public static class SurfSpotCatalog
{
    public static readonly IReadOnlyList<SurfSpot> All =
    [
        new()
        {
            Id = new Guid("9b283513-697e-4a41-aaf5-c9c1c4eacaff"),
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
            Id = new Guid("e997bc0f-4267-423f-b018-300f2ab68238"),
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
            Id = new Guid("83c3e03b-6c53-4d56-8459-e3b93e9c510f"),
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
            Id = new Guid("d972655c-fd80-48b2-a9d5-843e8dcbd153"),
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
            Id = new Guid("fe120869-eb8b-4962-bf24-d9e83a3ef3fe"),
            Name = "Makorori Point",
            Region = Region.Gisborne,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Longboard, BoardType.Fish, BoardType.Shortboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A cruisy right-hand cobblestone point just north of Gisborne — long, fat shoulders ideal for cruising and carving. Sister break to North Makorori Reef across the bay. Gets busy on good days but localism is rare for New Zealand; best on a solid SE swell with a light offshore."
        },
        new()
        {
            Id = new Guid("5461358c-f193-4e36-82a0-ad5da43909ae"),
            Name = "Scarborough",
            Region = Region.Christchurch,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Longboard, BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "Arguably Christchurch's single best surf spot — a right-hand point that peels from the headland over 100 metres into the bay, protected from easterlies by cliffs and a breakwater. Soft and mellow waves make it a longboarder's dream, while bigger winter swells bring out the performance surfers."
        },
        new()
        {
            Id = new Guid("c08fa569-6643-4842-b5a7-1349659a41cb"),
            Name = "Mangawhai Heads",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
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
            Id = new Guid("99d031a1-bed7-44b3-8217-5089e335c396"),
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
            Id = new Guid("5b8a8775-d285-4c8d-b4c7-e9410f8cc698"),
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
            Id = new Guid("2f3b5dc5-36a7-4069-a349-91ab4af657fc"),
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
            Id = new Guid("88334bce-7cd9-42cd-8ae9-85f4bf2b71fc"),
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
            Id = new Guid("a369bf4f-1c77-4a5c-848c-f136d5b866c7"),
            Name = "Muriwai",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub, Facility.Lifeguard],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "Auckland's most powerful West Coast beach break, taking the full force of Tasman Sea swells. Sucky, punchy peaks reward experienced surfers — strong rips make it unsuitable for beginners. Check Maori Bay just around the headland for slightly more sheltered lefts and rights when Muriwai closes out."
        },
        new()
        {
            Id = new Guid("a539f8d9-e30b-43ef-be31-529f991693b9"),
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
            Description = "Auckland's most iconic surf beach — one of the best on the North Island's West Coast. Sucky beach break with excellent lefts and rights off Lion Rock, set against dramatic black-sand cliffs. Heavy rips and powerful shore dump demand solid ocean experience; beginners should surf between the flags only."
        },
        new()
        {
            Id = new Guid("5471f752-5f17-44f9-b0fb-b5a5adfa07c6"),
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
            Id = new Guid("df46bcbe-0ebc-4910-a112-1e3bc0471559"),
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
            Id = new Guid("9fad49c3-00c3-46a1-893c-88349b410a41"),
            Name = "Pauanui",
            Region = Region.BayOfPlenty,
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
            Id = new Guid("a8de5b53-30d6-4558-a690-71bafa56acc0"),
            Name = "Whangamata",
            Region = Region.BayOfPlenty,
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
            Id = new Guid("e28a0c71-4b34-4544-9f33-19c941bc1375"),
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
            Id = new Guid("56e492f5-04ad-42b4-8b90-0091f36685fc"),
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
            Id = new Guid("2d8931ef-7b3c-480c-99c1-ac27f1f6df5f"),
            Name = "Bethells Beach",
            Region = Region.Auckland,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A dramatic black-sand beach tucked in a valley west of Auckland. Powerful beach break that rewards those who respect its conditions."
        },
        new()
        {
            Id = new Guid("2cb08af2-836e-4f5e-a7e2-14aa572b68c4"),
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
            Id = new Guid("f60b983b-9353-4387-9917-7c058735b7f6"),
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
            Id = new Guid("f4a5d3ca-048d-4905-9a93-8cf92fabc2b9"),
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
            Id = new Guid("2e9d55ab-daf5-4141-94a2-d565db0db508"),
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
            Id = new Guid("78edcc0a-476c-4bd1-83ad-0471284eb0bc"),
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
            Id = new Guid("afe79384-de57-4288-bb89-362d08d3d6e4"),
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
            Id = new Guid("9eeb5861-d0bc-4cb9-84b3-f1174940ea7f"),
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
            Description = "Beefy, strong, and occasionally rippable year-round beach break just north of Gisborne — most reliable from autumn to spring. At full tide the reef sections punch up. Stock Route, the short tubular runner on the south end, fires up on the right swell. One of the East Coast's most consistent waves."
        },

        // ── Kaikoura ──────────────────────────────────────────────────────────

        new()
        {
            Id = new Guid("4d237b3e-7a1f-4a45-9935-8913929c5a7e"),
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
            Description = "A heavy point/reef break tucked below the Kaikoura mountains, named after the old freezing works nearby. Fast takeoffs into hollow sections over boulders and rocks — unpredictability increased post-2016 earthquake. Expert-only on larger swells; approach with local knowledge."
        },
        new()
        {
            Id = new Guid("674759a2-93b5-4946-aa2f-237b42c7466c"),
            Name = "Mangamaunu",
            Region = Region.Kaikoura,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Longboard, BoardType.Shortboard, BoardType.Fish],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Busy,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "The jewel in Kaikoura's surf crown — a long, peeling left-to-right bay break that fills the whole bay with some of the longest rides this side of Raglan. Steady offshore winds, incredible mountain views, and consistent winter swells from the east make this one of the South Island's most celebrated waves."
        },

        // ── Christchurch (additional) ─────────────────────────────────────────

        new()
        {
            Id = new Guid("9aabf94d-fdaf-47e3-8616-e50123dd33c7"),
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
            Id = new Guid("d49fe9f4-6e17-4a0b-a907-c529aef18fba"),
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
            Id = new Guid("96964eda-9754-4e3d-bf49-6a813e35f7f0"),
            Name = "Tairua",
            Region = Region.BayOfPlenty,
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
            Id = new Guid("222ea40c-6ba4-4b8c-b5d4-8a65f7e0702e"),
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
            Description = "Wellington's premier year-round surf beach, right beside the airport. Sand-bottomed peaks work for all levels at all times of year, with minimal localism — the friendliest lineup in the city. Fires best on calm mornings before the notorious afternoon northerly kicks in. Board hire and lessons available from the surf club."
        },
        new()
        {
            Id = new Guid("37a14764-caad-42e5-8e6e-5240a8e9e378"),
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
            Id = new Guid("57c0b8c7-6ecf-4cb8-8634-ce6da7b08d25"),
            Name = "Makara Beach",
            Region = Region.Wellington,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
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
            Id = new Guid("e2c7acb6-000e-4933-b2b5-5f2a26f2a335"),
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
            Id = new Guid("079ddd51-4279-453c-81af-b661e1a97f70"),
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
        },

        // ── Kaikoura (additional) ─────────────────────────────────────────────

        new()
        {
            Id = new Guid("987dfab8-acc2-4dc1-b184-312374c9375d"),
            Name = "Kaikoura Point",
            Region = Region.Kaikoura,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Longboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "A right-hand point break at the town end of Kaikoura, wrapping around the peninsula alongside the fur-seal colony. Mellower and more accessible than Mangamaunu further up the coast, with the town's cafes and gear hire close at hand."
        },
        new()
        {
            Id = new Guid("320f04de-34f7-4d2f-8a50-e6d079cf75ec"),
            Name = "Okiwi Bay",
            Region = Region.Kaikoura,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "A sheltered beach break south of Kaikoura town with low, easy-going waves ideal for novices. Protected from northerlies and shallow enough for foam boards — popular with surf schools on summer mornings. Arrive early to beat the crowds."
        },
        new()
        {
            Id = new Guid("1c35bc8a-9789-42a4-9bd4-368f5c774ec7"),
            Name = "Gooch's Beach",
            Region = Region.Kaikoura,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Shortboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "The closest break to Kaikoura town — a convenient option when you only have an hour to spare. Fun peaks go left and right on medium-swell days, and there's enough whitewash on smaller days for beginners. Nothing special, but reliably rideable."
        },
        new()
        {
            Id = new Guid("7c926dd3-e07d-496d-81d1-c4821e0546fb"),
            Name = "Ward Beach",
            Region = Region.Kaikoura,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A beach and point break combo north of Kaikoura that improved noticeably after the 2016 earthquake. Best on bigger swells when both the beach and the point fill in — watch for the shallow shore break and stick to low tide on larger days. Dolphins are common."
        },

        // ── Christchurch (additional) ─────────────────────────────────────────

        new()
        {
            Id = new Guid("82d57d3e-60a4-48b6-bb65-dfb072918add"),
            Name = "New Brighton",
            Region = Region.Christchurch,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Shortboard],
            Facilities = [Facility.Bathrooms, Facility.Showers, Facility.SurfClub, Facility.Lifeguard, Facility.Rentals],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "Christchurch's most popular surf beach, stretching north from the famous pier. Consistent beach break peaks on most swells, full facilities, and a surf club that runs lessons — the go-to spot for the city."
        },
        new()
        {
            Id = new Guid("25e8876b-5560-4052-9e23-8fa5bf034073"),
            Name = "Waimairi Beach",
            Region = Region.Christchurch,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Shortboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "A long stretch of sand north of New Brighton with peaky, mellow waves that punch up on winter swells. A good escape when New Brighton gets crowded — shifting sandbanks keep conditions varied, and a local surf school operates here through summer."
        },
        new()
        {
            Id = new Guid("6c44f559-d734-4cf1-9a78-beba7b07cf7f"),
            Name = "Magnet Bay",
            Region = Region.Christchurch,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Longboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A longboarder's dream about an hour south of Christchurch — a left-hand point off a boulder-dotted beach that produces some of the longest rides in the Canterbury region. Gets busy on solid south swells; arrive early for a smaller lineup."
        },

        // ── Otago (additional) ────────────────────────────────────────────────

        new()
        {
            Id = new Guid("08ea9e93-ad99-4a50-8e38-5a16894a080a"),
            Name = "Aramoana",
            Region = Region.Otago,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A wild beach break at the mouth of Otago Harbour with a genuine sense of isolation. The sandbars shift constantly and the Southern Ocean swells arrive unimpeded — rewarding for those willing to make the drive out to the peninsula."
        },
        new()
        {
            Id = new Guid("ffbb6992-3993-4712-b693-41412ec1cb2c"),
            Name = "Blackhead",
            Region = Region.Otago,
            WaveType = WaveType.ReefBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish],
            Facilities = [],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "A raw reef break on the exposed southern edge of Dunedin, south of St Clair. Picks up more swell than anywhere else in the area and delivers punchy, hollow waves for those who venture this far — rarely crowded even on good days."
        },

        // ── Wellington (additional) ───────────────────────────────────────────

        new()
        {
            Id = new Guid("b428d363-06a3-42c1-bed6-4d6f50340717"),
            Name = "Pencarrow Head",
            Region = Region.Wellington,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Longboard],
            Facilities = [],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "A peeling left-hand point at the entrance to Wellington Harbour, working best on strong southerly swells through the winter months. A quieter alternative to Lyall Bay with a more committed paddle out — watch for the SW crosswind that can make it choppy in the afternoon."
        },
        new()
        {
            Id = new Guid("f06841b9-b3be-49db-82e9-8dec588e3207"),
            Name = "Houghton Bay",
            Region = Region.Wellington,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A dramatic south-facing bay in Wellington's western suburbs with a muscular right-hander point at its south end. A solid option when Lyall Bay is too crowded — the scenery is stunning and the waves have real character. Catches the same south swells as Lyall Bay."
        },

        // ── Taranaki (additional) ─────────────────────────────────────────────


        // ── Gisborne (additional) ─────────────────────────────────────────────

        new()
        {
            Id = new Guid("cde176c8-1e45-457b-9b30-c1fd73561ea5"),
            Name = "Sponge Bay",
            Region = Region.Gisborne,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Shortboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.AnkleHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.KneeHigh,
            Description = "An uber-fun, accessible beach south of Gisborne with a mellow peeler that sections into glassy walls and frothing whitewash. Both a left and right point wrap around the bay, catching refracted south swells that can be smaller and cleaner than Wainui. Good for all levels on most days."
        },

        // ── Waikato (additional) ──────────────────────────────────────────────

        new()
        {
            Id = new Guid("6dfb9b90-fbed-49fa-9bf4-26b6f64027e0"),
            Name = "Whale Bay",
            Region = Region.Waikato,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Intermediate,
            SuitableBoardTypes = [BoardType.Longboard, BoardType.Fish, BoardType.Shortboard],
            Facilities = [],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "The furthest and most rewarding of Raglan's three famous left-handers, a 20-minute walk from Whale Bay car park. Longer and more powerful than Manu Bay on a good swell, with a classic point-break shape that draws surfers from around the world."
        },

        new()
        {
            Id = new Guid("a69840d9-5d56-41f8-926b-efc39eb7363a"),
            Name = "Indicators",
            Region = Region.Waikato,
            WaveType = WaveType.PointBreak,
            MinSkillLevel = SkillLevel.Advanced,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish],
            Facilities = [],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.HeadHigh,
            Description = "Heavy take-off and uber-fast hollow sections with seriously long rides. Two entry points: Outsides for those new to NZ lefts, Insides for the committed expert. Prized by locals and often considered the most rewarding of Raglan's three point breaks."
        },

        new()
        {
            Id = new Guid("b9d233c7-01f7-48ba-b393-6ab66b91d936"),
            Name = "Ruapuke Beach",
            Region = Region.Waikato,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Rental, BoardType.Longboard, BoardType.Funboard, BoardType.Shortboard],
            Facilities = [],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.KneeHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A consistent swell magnet about 35 minutes from Raglan town on black sand. Multiple peaks for all abilities on smaller days — shoulder-high and mellow at its best. A reliable alternative when Manu Bay and Whale Bay are too heavy."
        },

        // ── Coromandel (additional) ───────────────────────────────────────────

        new()
        {
            Id = new Guid("80bc2dbd-50b6-4396-94a1-bc73a1ef9192"),
            Name = "Hot Water Beach",
            Region = Region.BayOfPlenty,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "Famous for its thermal springs at low tide, Hot Water Beach also delivers solid beach-break surf when a decent easterly swell wraps in. Most visitors come for the springs, which means the water is often surprisingly uncrowded — arrive early and score both."
        },


        // ── West Coast ────────────────────────────────────────────────────────

        new()
        {
            Id = new Guid("6c8776eb-d2dc-485d-98dd-24558d15efc1"),
            Name = "Punakaiki",
            Region = Region.WestCoast,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A wild beach break beside the famous Pancake Rocks on the Paparoa coast. Raw Tasman Sea swells hit the black-sand beach with real power — almost never crowded, and the scenery is unlike anywhere else in New Zealand."
        },
        new()
        {
            Id = new Guid("bc88f11c-88ac-4fb1-ac5b-984488ff2800"),
            Name = "Hokitika Beach",
            Region = Region.WestCoast,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.SurfClub],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "The most accessible surf beach on the West Coast, right at the edge of Hokitika town. Consistent Tasman Sea swells break over dark sand with no crowds — the town's sunsets here are legendary, and the pounamu shops make the trip worthwhile rain or shine."
        },

        // ── BayOfPlenty (additional) ──────────────────────────────────────────

        new()
        {
            Id = new Guid("5de53267-9ae1-4c46-a3e8-3b7fcca20fd8"),
            Name = "Waihau Bay",
            Region = Region.BayOfPlenty,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Campground],
            TypicalCrowd = CrowdLevel.Quiet,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A remote beach break on the East Cape road well north of Opotiki. Powerful, exposed swells hit the bay with little refraction, producing fast and hollow beach-break sections. The campground is basic but the waves — and the absence of crowds — are the whole point."
        },
        new()
        {
            Id = new Guid("8e89b39f-4425-48ae-8a7b-4b0fc2313168"),
            Name = "Papamoa Beach",
            Region = Region.BayOfPlenty,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.SurfClub],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.DoubleOverhead,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A high-quality beach break southeast of Mount Maunganui that gets punchy and responsive on NE swells over two feet. Slightly fewer crowds than the Mount itself, a friendly local surf club with no localism, and fast shoulders on bigger sets. One of the Bay of Plenty's best-kept secrets."
        },
        new()
        {
            Id = new Guid("5adf6b95-f296-4cd0-9178-24f0e16587ec"),
            Name = "Tay Street",
            Region = Region.BayOfPlenty,
            WaveType = WaveType.BeachBreak,
            MinSkillLevel = SkillLevel.Beginner,
            SuitableBoardTypes = [BoardType.Shortboard, BoardType.Fish, BoardType.Funboard],
            Facilities = [Facility.Bathrooms, Facility.Showers],
            TypicalCrowd = CrowdLevel.Moderate,
            MinWaveSize = WaveSize.WaistHigh,
            MaxWaveSize = WaveSize.HeadHigh,
            CurrentWaveSize = WaveSize.WaistHigh,
            Description = "A long beachfront strip south of Mount Maunganui main beach where waves lump up over the sandbars with fast drop-ins both left and right. Forgiving sand bottom, fewer swimmers than the Mount, and reliable shape on most NE swells — a great training ground for improving intermediates."
        }
    ];
}
