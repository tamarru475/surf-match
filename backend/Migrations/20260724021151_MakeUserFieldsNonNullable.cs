using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserFieldsNonNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"));

            migrationBuilder.AlterColumn<string>(
                name: "TikTokHandle",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstagramHandle",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AvatarUrl",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PreferredRegion",
                table: "user_preferences",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "surf_spots",
                columns: new[] { "Id", "CreatedAt", "CurrentWaveSize", "Description", "Facilities", "MaxWaveSize", "MinSkillLevel", "MinWaveSize", "Name", "Region", "SuitableBoardTypes", "TypicalCrowd", "WaveType" },
                values: new object[,]
                {
                    { new Guid("079ddd51-4279-453c-81af-b661e1a97f70"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "Dunedin's quieter neighbour to St Clair, sharing the same reliable Southern Ocean swells on a long exposed beach with consistent peaks. A good choice when St Clair is too busy.", new List<string> { "Bathrooms", "SurfClub" }, "HeadHigh", "Beginner", "AnkleHigh", "St Kilda", "Otago", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Quiet", "BeachBreak" },
                    { new Guid("08ea9e93-ad99-4a50-8e38-5a16894a080a"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A wild beach break at the mouth of Otago Harbour with a genuine sense of isolation. The sandbars shift constantly and the Southern Ocean swells arrive unimpeded — rewarding for those willing to make the drive out to the peninsula.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Aramoana", "Otago", new List<string> { "Shortboard", "Fish", "Funboard" }, "Quiet", "BeachBreak" },
                    { new Guid("222ea40c-6ba4-4b8c-b5d4-8a65f7e0702e"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "Wellington's most accessible surf beach, right next to the airport. Consistent swell from Cook Strait makes it reliable year-round, though it fires best on calm mornings before the afternoon northerly kicks in.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, "HeadHigh", "Beginner", "AnkleHigh", "Lyall Bay", "Wellington", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" }, "Busy", "BeachBreak" },
                    { new Guid("2cb08af2-836e-4f5e-a7e2-14aa572b68c4"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A hidden gem near Tutukaka in Northland. Sandy bottom beach break that rarely gets crowded — worth tracking down.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "KneeHigh", "Sandy Bay", "Northland", new List<string> { "Shortboard", "Fish", "Funboard" }, "Quiet", "BeachBreak" },
                    { new Guid("2d8931ef-7b3c-480c-99c1-ac27f1f6df5f"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A dramatic black-sand beach tucked in a valley west of Auckland. Powerful beach break that rewards those who respect its conditions.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Bethells Beach", "Auckland", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("2e9d55ab-daf5-4141-94a2-d565db0db508"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "The main surf break in New Plymouth, breaking over a mix of reef and sand beneath the volcanic headland. Punchy and powerful when it lines up.", new List<string> { "Bathrooms", "Showers", "SurfClub" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Back Beach", "Taranaki", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "ReefBreak" },
                    { new Guid("2f3b5dc5-36a7-4069-a349-91ab4af657fc"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A tucked-away beach inside a conservation area north of Mangawhai. Worth the walk in for quality, uncrowded waves.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "KneeHigh", "Te Arai", "Auckland", new List<string> { "Shortboard", "Fish", "Longboard" }, "Quiet", "BeachBreak" },
                    { new Guid("337ae4b8-aca6-46e8-a841-e9b99a5e3d92"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A sheltered bay north of Wellington in Porirua, offering some of the most consistent and manageable beach break on the lower North Island. The surf club is active, lifeguards patrol in summer, and the sand-bottom waves are kind to learners.", new List<string> { "Bathrooms", "SurfClub", "Lifeguard" }, "HeadHigh", "Beginner", "AnkleHigh", "Titahi Bay", "Wellington", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Moderate", "BeachBreak" },
                    { new Guid("37a14764-caad-42e5-8e6e-5240a8e9e378"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A dramatic lighthouse bay on the Wairarapa coast, two hours from Wellington. A reef break that fires with powerful East Coast swells — the remote setting and iconic scenery make the drive very much worth it.", new List<string> { "Bathrooms", "Campground" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Castlepoint", "Wellington", new List<string> { "Shortboard", "Fish" }, "Quiet", "ReefBreak" },
                    { new Guid("3e820cf6-fcd6-4731-b8e3-25860248bc4f"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A friendly beach break 15 km south of New Plymouth with a strong community surf club. Mellow rolling waves are perfect for learners and longboarders, and the campground makes it easy to stay and score multiple sessions.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Campground" }, "HeadHigh", "Beginner", "AnkleHigh", "Oakura", "Taranaki", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" }, "Moderate", "BeachBreak" },
                    { new Guid("4d237b3e-7a1f-4a45-9935-8913929c5a7e"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A powerful left-hand reef break tucked below the Kaikoura mountains. Named after the old meatworks nearby — raw, heavy, and stunning when it's firing.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Advanced", "WaistHigh", "Meatworks", "Kaikoura", new List<string> { "Shortboard", "Fish" }, "Quiet", "ReefBreak" },
                    { new Guid("5252189f-a966-4a43-958f-f4a388883eff"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A semi-secret right-hander on Taranaki's Surf Highway 45 that peels along a rocky point with impressive length on a solid southerly swell. Known mainly to locals, it rewards those willing to hike a short distance from the road.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Komene Road", "Taranaki", new List<string> { "Shortboard", "Fish", "Longboard" }, "Quiet", "PointBreak" },
                    { new Guid("5461358c-f193-4e36-82a0-ad5da43909ae"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "Tucked beside Sumner, Scarborough picks up solid South Island swells and offers punchy beach break waves in a scenic setting.", new List<string> { "Bathrooms", "Showers" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Scarborough", "Christchurch", new List<string> { "Shortboard", "Fish", "Longboard" }, "Moderate", "BeachBreak" },
                    { new Guid("5471f752-5f17-44f9-b0fb-b5a5adfa07c6"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "Inside a protected regional park on the Tawharanui Peninsula. A peaceful beach break with low crowds and a campground for an overnight trip.", new List<string> { "Bathrooms", "Campground" }, "HeadHigh", "Beginner", "KneeHigh", "Tawharanui", "Auckland", new List<string> { "Longboard", "Funboard", "Fish" }, "Quiet", "BeachBreak" },
                    { new Guid("56e492f5-04ad-42b4-8b90-0091f36685fc"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "DoubleOverhead", "One of New Zealand's longest left-hand point breaks, near Ahipara at the foot of Ninety Mile Beach. Remote and raw — a reward for the committed.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Advanced", "WaistHigh", "Shipwreck Bay", "Northland", new List<string> { "Shortboard", "Fish" }, "Quiet", "PointBreak" },
                    { new Guid("57c0b8c7-6ecf-4cb8-8634-ce6da7b08d25"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A raw, wind-exposed beach break on Wellington's rugged west coast. Gets open-ocean swell that rarely reaches Lyall Bay — worth the extra drive when conditions align and the wind is light.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Makara Beach", "Wellington", new List<string> { "Shortboard", "Fish", "Funboard" }, "Quiet", "BeachBreak" },
                    { new Guid("5b8a8775-d285-4c8d-b4c7-e9410f8cc698"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A popular holiday beach north of Auckland that picks up decent swells and serves up fun beach break peaks across its length.", new List<string> { "Bathrooms", "Showers" }, "HeadHigh", "Beginner", "KneeHigh", "Omaha", "Auckland", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("5de53267-9ae1-4c46-a3e8-3b7fcca20fd8"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A remote beach break on the East Cape road well north of Opotiki. Powerful, exposed swells hit the bay with little refraction, producing fast and hollow beach-break sections. The campground is basic but the waves — and the absence of crowds — are the whole point.", new List<string> { "Bathrooms", "Campground" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Waihau Bay", "BayOfPlenty", new List<string> { "Shortboard", "Fish", "Funboard" }, "Quiet", "BeachBreak" },
                    { new Guid("6206f692-1cb2-4133-8685-fdcabe0ec9fb"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "An exposed and remote shingle-beach break at the southern tip of the Wairarapa. Punishing shore-dump sections between powerful peaks make this strictly for experienced surfers — the reward is almost complete solitude and serious South Coast power.", new List<string>(), "DoubleOverhead", "Advanced", "HeadHigh", "Palliser Bay", "Wellington", new List<string> { "Shortboard", "Fish" }, "Quiet", "BeachBreak" },
                    { new Guid("674759a2-93b5-4946-aa2f-237b42c7466c"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "One of New Zealand's longest right-hand point breaks, walling for hundreds of metres along the Kaikoura coastline. A remote gem that makes the drive from Christchurch very worthwhile.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Mangamaunu", "Kaikoura", new List<string> { "Longboard", "Shortboard", "Fish" }, "Quiet", "PointBreak" },
                    { new Guid("6dfb9b90-fbed-49fa-9bf4-26b6f64027e0"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "The furthest and most rewarding of Raglan's three famous left-handers, a 20-minute walk from Whale Bay car park. Longer and more powerful than Manu Bay on a good swell, with a classic point-break shape that draws surfers from around the world.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Whale Bay", "Waikato", new List<string> { "Longboard", "Fish", "Shortboard" }, "Moderate", "PointBreak" },
                    { new Guid("755ff886-92a0-4330-97c5-23a84a732fd7"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A wide open beach break stretching north from the Waimakariri River mouth. Rarely crowded and produces gentle, forgiving waves on smaller swells — popular for learners and those wanting a session away from the Sumner crowds.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "AnkleHigh", "Pegasus Bay", "Christchurch", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Quiet", "BeachBreak" },
                    { new Guid("78edcc0a-476c-4bd1-83ad-0471284eb0bc"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A reef break sitting just off Takapuna Beach on Auckland's North Shore. Can produce surprisingly good waves when the swell direction lines up.", new List<string> { "Bathrooms", "Showers", "SurfClub" }, "HeadHigh", "Intermediate", "KneeHigh", "Takapuna Reef", "Auckland", new List<string> { "Shortboard", "Fish" }, "Moderate", "ReefBreak" },
                    { new Guid("79cfd9cf-0424-4126-bab2-581177c7b3ef"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A quality right-hand reef point just north of Gisborne. Long, walling walls peel along a rock shelf and produce some of the most consistent point-break action on the East Coast — often offshore when inland areas are cross-shore.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Tatapouri", "Gisborne", new List<string> { "Shortboard", "Fish", "Longboard" }, "Quiet", "ReefBreak" },
                    { new Guid("80bc2dbd-50b6-4396-94a1-bc73a1ef9192"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "Famous for its thermal springs at low tide, Hot Water Beach also delivers solid beach-break surf when a decent easterly swell wraps in. Most visitors come for the springs, which means the water is often surprisingly uncrowded — arrive early and score both.", new List<string> { "Bathrooms", "Showers" }, "HeadHigh", "Intermediate", "WaistHigh", "Hot Water Beach", "Coromandel", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("82d57d3e-60a4-48b6-bb65-dfb072918add"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A sheltered cove on the Banks Peninsula, accessed via a winding hill road from Sumner. Offers both left and right reef peaks that are more protected from onshore winds than New Brighton — a favourite when the city beaches go messy.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Taylors Mistake", "Christchurch", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "ReefBreak" },
                    { new Guid("83c3e03b-6c53-4d56-8459-e3b93e9c510f"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "The Mount's main beach is a long, approachable beach break with excellent facilities. A great all-rounder spot suitable for every level.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, "HeadHigh", "Beginner", "KneeHigh", "Mount Maunganui", "BayOfPlenty", new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" }, "Busy", "BeachBreak" },
                    { new Guid("88334bce-7cd9-42cd-8ae9-85f4bf2b71fc"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "An Auckland beach break that rewards those who make the effort with uncrowded, quality waves away from the main beaches.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "WaistHigh", "Forestry", "Auckland", new List<string> { "Shortboard", "Fish" }, "Quiet", "BeachBreak" },
                    { new Guid("96964eda-9754-4e3d-bf49-6a813e35f7f0"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A sheltered harbour-mouth beach break on the Coromandel's east coast that picks up east and northeast swells well. A reliable option when the west side is flat.", new List<string> { "Bathrooms", "SurfClub" }, "WaistHigh", "Beginner", "AnkleHigh", "Tairua", "Coromandel", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Moderate", "BeachBreak" },
                    { new Guid("987dfab8-acc2-4dc1-b184-312374c9375d"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A right-hand point break at the town end of Kaikoura, wrapping around the peninsula alongside the fur-seal colony. Mellower and more accessible than Mangamaunu further up the coast, with the town's cafes and gear hire close at hand.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Kaikoura Point", "Kaikoura", new List<string> { "Shortboard", "Fish", "Longboard" }, "Moderate", "PointBreak" },
                    { new Guid("99d031a1-bed7-44b3-8217-5089e335c396"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "AnkleHigh", "A long, sheltered beach just north of Auckland city with gentle, rolling waves — ideal for beginners and longboarders.", new List<string> { "Bathrooms", "Showers", "Lifeguard" }, "WaistHigh", "Beginner", "AnkleHigh", "Orewa Beach", "Auckland", new List<string> { "Rental", "Longboard", "Funboard" }, "Busy", "BeachBreak" },
                    { new Guid("9aabf94d-fdaf-47e3-8616-e50123dd33c7"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A hidden bay east of Sumner with rocky headland rights that reward surfers willing to make the hike from the car park. One of Canterbury's most scenic and consistent breaks.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Taylor's Mistake", "Christchurch", new List<string> { "Shortboard", "Fish", "Longboard" }, "Quiet", "ReefBreak" },
                    { new Guid("9b283513-697e-4a41-aaf5-c9c1c4eacaff"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "Raglan's long sandy beach break. Consistent, gentle waves and lifeguard patrol make it the go-to beginner spot on the West Coast.", new List<string> { "Bathrooms", "Showers", "Rentals", "Lifeguard" }, "HeadHigh", "Beginner", "AnkleHigh", "Ngarunui Beach", "Waikato", new List<string> { "Rental", "Longboard", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("9eeb5861-d0bc-4cb9-84b3-f1174940ea7f"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A long sandy beach just north of Gisborne city with consistent beach break peaks. Popular with locals and a reliable option when the easterly swells arrive.", new List<string> { "Bathrooms", "Lifeguard" }, "HeadHigh", "Beginner", "AnkleHigh", "Wainui Beach", "Gisborne", new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" }, "Moderate", "BeachBreak" },
                    { new Guid("9fad49c3-00c3-46a1-893c-88349b410a41"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A pretty Coromandel beach break with fun, manageable waves — popular with holidaying families and surfers looking for a chill session.", new List<string> { "Bathrooms", "Showers" }, "HeadHigh", "Beginner", "KneeHigh", "Pauanui", "Coromandel", new List<string> { "Rental", "Longboard", "Funboard", "Fish" }, "Moderate", "BeachBreak" },
                    { new Guid("a369bf4f-1c77-4a5c-848c-f136d5b866c7"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "Auckland's wild black-sand West Coast beach. Powerful and consistent with strong rips — rewarding for surfers with solid ocean awareness.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Muriwai", "Auckland", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("a539f8d9-e30b-43ef-be31-529f991693b9"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "Auckland's most famous surf beach — powerful, dramatic, and stunning. Heavy rips demand solid ocean experience before paddling out.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Piha", "Auckland", new List<string> { "Shortboard", "Fish" }, "Busy", "BeachBreak" },
                    { new Guid("a8de5b53-30d6-4558-a690-71bafa56acc0"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "One of the Coromandel's most popular surf towns. Peaks fire up and down the beach and it's at its best during an easterly swell.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "HeadHigh", "Beginner", "WaistHigh", "Whangamata", "Coromandel", new List<string> { "Shortboard", "Fish", "Funboard" }, "Busy", "BeachBreak" },
                    { new Guid("afe79384-de57-4288-bb89-362d08d3d6e4"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A lesser-known Auckland reef that rewards those in the know with uncrowded, hollow waves when conditions align. Worth checking on a small easterly swell.", new List<string> { "Bathrooms" }, "HeadHigh", "Intermediate", "KneeHigh", "Daniels Reef", "Auckland", new List<string> { "Shortboard", "Fish" }, "Quiet", "ReefBreak" },
                    { new Guid("b40b8cff-c98f-469c-b78b-b13cdff6d25e"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A powerful reef break north of Kaikoura accessible only by walking along the rail corridor at low tide. Heavy, hollow waves break over a shallow ledge — for experienced surfers only and best surfed with a local guide.", new List<string>(), "DoubleOverhead", "Advanced", "HeadHigh", "Haumuri Bluffs", "Kaikoura", new List<string> { "Shortboard", "Fish" }, "Quiet", "ReefBreak" },
                    { new Guid("b8698048-bb61-47ac-8a52-0b9424061fb9"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A peaceful and seldom-visited beach break north of Gisborne with gentle, beginner-friendly waves on most swells. The lack of facilities and crowds makes it ideal for a quiet dawn patrol or an uncrowded afternoon session.", new List<string>(), "HeadHigh", "Beginner", "AnkleHigh", "Pouawa", "Gisborne", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Quiet", "BeachBreak" },
                    { new Guid("c08fa569-6643-4842-b5a7-1349659a41cb"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A reliable North Auckland beach break that delivers consistent surf and is usually less hectic than the city breaks.", new List<string> { "Bathrooms", "Showers", "SurfClub" }, "HeadHigh", "Intermediate", "KneeHigh", "Mangawhai Heads", "Auckland", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("d49fe9f4-6e17-4a0b-a907-c529aef18fba"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A long, sandy stretch east of Whakatane with mellow beach break peaks and plenty of space. One of the Bay of Plenty's quietest surf beaches — ideal for beginners wanting room to learn.", new List<string> { "Bathrooms", "Showers", "Lifeguard", "Campground" }, "WaistHigh", "Beginner", "AnkleHigh", "Ohope Beach", "BayOfPlenty", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Quiet", "BeachBreak" },
                    { new Guid("d972655c-fd80-48b2-a9d5-843e8dcbd153"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "Waikanae Beach sits right in town and offers mellow, learner-friendly waves backed by full beach facilities.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, "HeadHigh", "Beginner", "KneeHigh", "Gisborne Town", "Gisborne", new List<string> { "Rental", "Longboard", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("df46bcbe-0ebc-4910-a112-1e3bc0471559"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A long, welcoming Bay of Plenty beach break. Consistent and forgiving — good for beginners and longboarders making the most of summer.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "HeadHigh", "Beginner", "KneeHigh", "Waihi Beach", "BayOfPlenty", new List<string> { "Rental", "Longboard", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("e28a0c71-4b34-4544-9f33-19c941bc1375"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "AnkleHigh", "A sheltered Northland cove with mellow, beginner-friendly waves and a relaxed holiday vibe.", new List<string> { "Bathrooms", "Campground" }, "WaistHigh", "Beginner", "AnkleHigh", "Waipu Cove", "Northland", new List<string> { "Longboard", "Funboard", "Fish" }, "Quiet", "BeachBreak" },
                    { new Guid("e2c7acb6-000e-4933-b2b5-5f2a26f2a335"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "Dunedin's iconic surf beach at the foot of the Otago Peninsula. Reliable Southern Ocean swells, a surf club that's been running for over a century, and a famous saltwater hot pool right on the beachfront.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, "DoubleOverhead", "Beginner", "AnkleHigh", "St Clair Beach", "Otago", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" }, "Moderate", "BeachBreak" },
                    { new Guid("e997bc0f-4267-423f-b018-300f2ab68238"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "Raglan's iconic left-hand point break — one of the longest in the Southern Hemisphere. A bucket-list wave that draws surfers from around the world.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Manu Bay", "Waikato", new List<string> { "Longboard", "Shortboard", "Fish" }, "Busy", "PointBreak" },
                    { new Guid("f4a5d3ca-048d-4905-9a93-8cf92fabc2b9"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A mellow reef break in Taranaki that turns on when other spots are too big. A local favourite that stays quiet even on good days.", new List<string> { "Bathrooms" }, "HeadHigh", "Intermediate", "KneeHigh", "Kumara Patch", "Taranaki", new List<string> { "Shortboard", "Fish", "Funboard" }, "Quiet", "ReefBreak" },
                    { new Guid("f60b983b-9353-4387-9917-7c058735b7f6"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A long, walling left-hand reef break near Oakura. One of Taranaki's most consistent and rewarding waves — best at solid swell with a light offshore.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Advanced", "WaistHigh", "Stent Road", "Taranaki", new List<string> { "Shortboard", "Fish" }, "Moderate", "ReefBreak" },
                    { new Guid("fe120869-eb8b-4962-bf24-d9e83a3ef3fe"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A cobblestone right-hander just north of Gisborne. Quieter than the town beach with fun point break walls on a good swell.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Makorori Point", "Gisborne", new List<string> { "Longboard", "Fish", "Shortboard" }, "Quiet", "PointBreak" },
                    { new Guid("ffbb6992-3993-4712-b693-41412ec1cb2c"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A raw reef break on the exposed southern edge of Dunedin, south of St Clair. Picks up more swell than anywhere else in the area and delivers punchy, hollow waves for those who venture this far — rarely crowded even on good days.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Blackhead", "Otago", new List<string> { "Shortboard", "Fish" }, "Quiet", "ReefBreak" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("079ddd51-4279-453c-81af-b661e1a97f70"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("08ea9e93-ad99-4a50-8e38-5a16894a080a"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("222ea40c-6ba4-4b8c-b5d4-8a65f7e0702e"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2cb08af2-836e-4f5e-a7e2-14aa572b68c4"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2d8931ef-7b3c-480c-99c1-ac27f1f6df5f"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2e9d55ab-daf5-4141-94a2-d565db0db508"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2f3b5dc5-36a7-4069-a349-91ab4af657fc"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("337ae4b8-aca6-46e8-a841-e9b99a5e3d92"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("37a14764-caad-42e5-8e6e-5240a8e9e378"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("3e820cf6-fcd6-4731-b8e3-25860248bc4f"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("4d237b3e-7a1f-4a45-9935-8913929c5a7e"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5252189f-a966-4a43-958f-f4a388883eff"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5461358c-f193-4e36-82a0-ad5da43909ae"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5471f752-5f17-44f9-b0fb-b5a5adfa07c6"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("56e492f5-04ad-42b4-8b90-0091f36685fc"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("57c0b8c7-6ecf-4cb8-8634-ce6da7b08d25"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5b8a8775-d285-4c8d-b4c7-e9410f8cc698"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5de53267-9ae1-4c46-a3e8-3b7fcca20fd8"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("6206f692-1cb2-4133-8685-fdcabe0ec9fb"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("674759a2-93b5-4946-aa2f-237b42c7466c"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("6dfb9b90-fbed-49fa-9bf4-26b6f64027e0"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("755ff886-92a0-4330-97c5-23a84a732fd7"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("78edcc0a-476c-4bd1-83ad-0471284eb0bc"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("79cfd9cf-0424-4126-bab2-581177c7b3ef"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("80bc2dbd-50b6-4396-94a1-bc73a1ef9192"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("82d57d3e-60a4-48b6-bb65-dfb072918add"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("83c3e03b-6c53-4d56-8459-e3b93e9c510f"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("88334bce-7cd9-42cd-8ae9-85f4bf2b71fc"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("96964eda-9754-4e3d-bf49-6a813e35f7f0"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("987dfab8-acc2-4dc1-b184-312374c9375d"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("99d031a1-bed7-44b3-8217-5089e335c396"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9aabf94d-fdaf-47e3-8616-e50123dd33c7"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9b283513-697e-4a41-aaf5-c9c1c4eacaff"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9eeb5861-d0bc-4cb9-84b3-f1174940ea7f"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9fad49c3-00c3-46a1-893c-88349b410a41"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a369bf4f-1c77-4a5c-848c-f136d5b866c7"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a539f8d9-e30b-43ef-be31-529f991693b9"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a8de5b53-30d6-4558-a690-71bafa56acc0"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("afe79384-de57-4288-bb89-362d08d3d6e4"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("b40b8cff-c98f-469c-b78b-b13cdff6d25e"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("b8698048-bb61-47ac-8a52-0b9424061fb9"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("c08fa569-6643-4842-b5a7-1349659a41cb"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("d49fe9f4-6e17-4a0b-a907-c529aef18fba"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("d972655c-fd80-48b2-a9d5-843e8dcbd153"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("df46bcbe-0ebc-4910-a112-1e3bc0471559"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("e28a0c71-4b34-4544-9f33-19c941bc1375"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("e2c7acb6-000e-4933-b2b5-5f2a26f2a335"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("e997bc0f-4267-423f-b018-300f2ab68238"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("f4a5d3ca-048d-4905-9a93-8cf92fabc2b9"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("f60b983b-9353-4387-9917-7c058735b7f6"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("fe120869-eb8b-4962-bf24-d9e83a3ef3fe"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("ffbb6992-3993-4712-b693-41412ec1cb2c"));

            migrationBuilder.AlterColumn<string>(
                name: "TikTokHandle",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "InstagramHandle",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AvatarUrl",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PreferredRegion",
                table: "user_preferences",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "surf_spots",
                columns: new[] { "Id", "CreatedAt", "CurrentWaveSize", "Description", "Facilities", "MaxWaveSize", "MinSkillLevel", "MinWaveSize", "Name", "Region", "SuitableBoardTypes", "TypicalCrowd", "WaveType" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "Raglan's long sandy beach break. Consistent, gentle waves and lifeguard patrol make it the go-to beginner spot on the West Coast.", new List<string> { "Bathrooms", "Showers", "Rentals", "Lifeguard" }, "HeadHigh", "Beginner", "AnkleHigh", "Ngarunui Beach", "Waikato", new List<string> { "Rental", "Longboard", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "Raglan's iconic left-hand point break — one of the longest in the Southern Hemisphere. A bucket-list wave that draws surfers from around the world.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Manu Bay", "Waikato", new List<string> { "Longboard", "Shortboard", "Fish" }, "Busy", "PointBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "The Mount's main beach is a long, approachable beach break with excellent facilities. A great all-rounder spot suitable for every level.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, "HeadHigh", "Beginner", "KneeHigh", "Mount Maunganui", "BayOfPlenty", new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" }, "Busy", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "Waikanae Beach sits right in town and offers mellow, learner-friendly waves backed by full beach facilities.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, "HeadHigh", "Beginner", "KneeHigh", "Gisborne Town", "Gisborne", new List<string> { "Rental", "Longboard", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A cobblestone right-hander just north of Gisborne. Quieter than the town beach with fun point break walls on a good swell.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Makorori Point", "Gisborne", new List<string> { "Longboard", "Fish", "Shortboard" }, "Quiet", "PointBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "Tucked beside Sumner, Scarborough picks up solid South Island swells and offers punchy beach break waves in a scenic setting.", new List<string> { "Bathrooms", "Showers" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Scarborough", "Christchurch", new List<string> { "Shortboard", "Fish", "Longboard" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A reliable North Auckland beach break that delivers consistent surf and is usually less hectic than the city breaks.", new List<string> { "Bathrooms", "Showers", "SurfClub" }, "HeadHigh", "Intermediate", "KneeHigh", "Mangawhai Heads", "Auckland", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "AnkleHigh", "A long, sheltered beach just north of Auckland city with gentle, rolling waves — ideal for beginners and longboarders.", new List<string> { "Bathrooms", "Showers", "Lifeguard" }, "WaistHigh", "Beginner", "AnkleHigh", "Orewa Beach", "Auckland", new List<string> { "Rental", "Longboard", "Funboard" }, "Busy", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A popular holiday beach north of Auckland that picks up decent swells and serves up fun beach break peaks across its length.", new List<string> { "Bathrooms", "Showers" }, "HeadHigh", "Beginner", "KneeHigh", "Omaha", "Auckland", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A tucked-away beach inside a conservation area north of Mangawhai. Worth the walk in for quality, uncrowded waves.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "KneeHigh", "Te Arai", "Auckland", new List<string> { "Shortboard", "Fish", "Longboard" }, "Quiet", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "An Auckland beach break that rewards those who make the effort with uncrowded, quality waves away from the main beaches.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "WaistHigh", "Forestry", "Auckland", new List<string> { "Shortboard", "Fish" }, "Quiet", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "Auckland's wild black-sand West Coast beach. Powerful and consistent with strong rips — rewarding for surfers with solid ocean awareness.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Muriwai", "Auckland", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "Auckland's most famous surf beach — powerful, dramatic, and stunning. Heavy rips demand solid ocean experience before paddling out.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Piha", "Auckland", new List<string> { "Shortboard", "Fish" }, "Busy", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "Inside a protected regional park on the Tawharanui Peninsula. A peaceful beach break with low crowds and a campground for an overnight trip.", new List<string> { "Bathrooms", "Campground" }, "HeadHigh", "Beginner", "KneeHigh", "Tawharanui", "Auckland", new List<string> { "Longboard", "Funboard", "Fish" }, "Quiet", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A long, welcoming Bay of Plenty beach break. Consistent and forgiving — good for beginners and longboarders making the most of summer.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "HeadHigh", "Beginner", "KneeHigh", "Waihi Beach", "BayOfPlenty", new List<string> { "Rental", "Longboard", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A pretty Coromandel beach break with fun, manageable waves — popular with holidaying families and surfers looking for a chill session.", new List<string> { "Bathrooms", "Showers" }, "HeadHigh", "Beginner", "KneeHigh", "Pauanui", "Coromandel", new List<string> { "Rental", "Longboard", "Funboard", "Fish" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "One of the Coromandel's most popular surf towns. Peaks fire up and down the beach and it's at its best during an easterly swell.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "HeadHigh", "Beginner", "WaistHigh", "Whangamata", "Coromandel", new List<string> { "Shortboard", "Fish", "Funboard" }, "Busy", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "AnkleHigh", "A sheltered Northland cove with mellow, beginner-friendly waves and a relaxed holiday vibe.", new List<string> { "Bathrooms", "Campground" }, "WaistHigh", "Beginner", "AnkleHigh", "Waipu Cove", "Northland", new List<string> { "Longboard", "Funboard", "Fish" }, "Quiet", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "DoubleOverhead", "One of New Zealand's longest left-hand point breaks, near Ahipara at the foot of Ninety Mile Beach. Remote and raw — a reward for the committed.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Advanced", "WaistHigh", "Shipwreck Bay", "Northland", new List<string> { "Shortboard", "Fish" }, "Quiet", "PointBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A dramatic black-sand beach tucked in a valley west of Auckland. Powerful beach break that rewards those who respect its conditions.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Bethells Beach", "Auckland", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A hidden gem near Tutukaka in Northland. Sandy bottom beach break that rarely gets crowded — worth tracking down.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "KneeHigh", "Sandy Bay", "Northland", new List<string> { "Shortboard", "Fish", "Funboard" }, "Quiet", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A long, walling left-hand reef break near Oakura. One of Taranaki's most consistent and rewarding waves — best at solid swell with a light offshore.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Advanced", "WaistHigh", "Stent Road", "Taranaki", new List<string> { "Shortboard", "Fish" }, "Moderate", "ReefBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A mellow reef break in Taranaki that turns on when other spots are too big. A local favourite that stays quiet even on good days.", new List<string> { "Bathrooms" }, "HeadHigh", "Intermediate", "KneeHigh", "Kumara Patch", "Taranaki", new List<string> { "Shortboard", "Fish", "Funboard" }, "Quiet", "ReefBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000024"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "The main surf break in New Plymouth, breaking over a mix of reef and sand beneath the volcanic headland. Punchy and powerful when it lines up.", new List<string> { "Bathrooms", "Showers", "SurfClub" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Back Beach", "Taranaki", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "ReefBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000025"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A reef break sitting just off Takapuna Beach on Auckland's North Shore. Can produce surprisingly good waves when the swell direction lines up.", new List<string> { "Bathrooms", "Showers", "SurfClub" }, "HeadHigh", "Intermediate", "KneeHigh", "Takapuna Reef", "Auckland", new List<string> { "Shortboard", "Fish" }, "Moderate", "ReefBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A lesser-known Auckland reef that rewards those in the know with uncrowded, hollow waves when conditions align. Worth checking on a small easterly swell.", new List<string> { "Bathrooms" }, "HeadHigh", "Intermediate", "KneeHigh", "Daniels Reef", "Auckland", new List<string> { "Shortboard", "Fish" }, "Quiet", "ReefBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A long sandy beach just north of Gisborne city with consistent beach break peaks. Popular with locals and a reliable option when the easterly swells arrive.", new List<string> { "Bathrooms", "Lifeguard" }, "HeadHigh", "Beginner", "AnkleHigh", "Wainui Beach", "Gisborne", new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000028"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A powerful left-hand reef break tucked below the Kaikoura mountains. Named after the old meatworks nearby — raw, heavy, and stunning when it's firing.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Advanced", "WaistHigh", "Meatworks", "Kaikoura", new List<string> { "Shortboard", "Fish" }, "Quiet", "ReefBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000029"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "One of New Zealand's longest right-hand point breaks, walling for hundreds of metres along the Kaikoura coastline. A remote gem that makes the drive from Christchurch very worthwhile.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Mangamaunu", "Kaikoura", new List<string> { "Longboard", "Shortboard", "Fish" }, "Quiet", "PointBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A hidden bay east of Sumner with rocky headland rights that reward surfers willing to make the hike from the car park. One of Canterbury's most scenic and consistent breaks.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Taylor's Mistake", "Christchurch", new List<string> { "Shortboard", "Fish", "Longboard" }, "Quiet", "ReefBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A long, sandy stretch east of Whakatane with mellow beach break peaks and plenty of space. One of the Bay of Plenty's quietest surf beaches — ideal for beginners wanting room to learn.", new List<string> { "Bathrooms", "Showers", "Lifeguard", "Campground" }, "WaistHigh", "Beginner", "AnkleHigh", "Ohope Beach", "BayOfPlenty", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Quiet", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A sheltered harbour-mouth beach break on the Coromandel's east coast that picks up east and northeast swells well. A reliable option when the west side is flat.", new List<string> { "Bathrooms", "SurfClub" }, "WaistHigh", "Beginner", "AnkleHigh", "Tairua", "Coromandel", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "Wellington's most accessible surf beach, right next to the airport. Consistent swell from Cook Strait makes it reliable year-round, though it fires best on calm mornings before the afternoon northerly kicks in.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, "HeadHigh", "Beginner", "AnkleHigh", "Lyall Bay", "Wellington", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" }, "Busy", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A dramatic lighthouse bay on the Wairarapa coast, two hours from Wellington. A reef break that fires with powerful East Coast swells — the remote setting and iconic scenery make the drive very much worth it.", new List<string> { "Bathrooms", "Campground" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Castlepoint", "Wellington", new List<string> { "Shortboard", "Fish" }, "Quiet", "ReefBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000035"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A raw, wind-exposed beach break on Wellington's rugged west coast. Gets open-ocean swell that rarely reaches Lyall Bay — worth the extra drive when conditions align and the wind is light.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Makara Beach", "Wellington", new List<string> { "Shortboard", "Fish", "Funboard" }, "Quiet", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000036"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "Dunedin's iconic surf beach at the foot of the Otago Peninsula. Reliable Southern Ocean swells, a surf club that's been running for over a century, and a famous saltwater hot pool right on the beachfront.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, "DoubleOverhead", "Beginner", "AnkleHigh", "St Clair Beach", "Otago", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" }, "Moderate", "BeachBreak" },
                    { new Guid("00000000-0000-0000-0000-000000000037"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "Dunedin's quieter neighbour to St Clair, sharing the same reliable Southern Ocean swells on a long exposed beach with consistent peaks. A good choice when St Clair is too busy.", new List<string> { "Bathrooms", "SurfClub" }, "HeadHigh", "Beginner", "AnkleHigh", "St Kilda", "Otago", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Quiet", "BeachBreak" }
                });
        }
    }
}
