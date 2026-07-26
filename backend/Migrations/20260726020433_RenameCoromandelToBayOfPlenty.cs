using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RenameCoromandelToBayOfPlenty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("337ae4b8-aca6-46e8-a841-e9b99a5e3d92"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("3e820cf6-fcd6-4731-b8e3-25860248bc4f"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5252189f-a966-4a43-958f-f4a388883eff"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("6206f692-1cb2-4133-8685-fdcabe0ec9fb"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("755ff886-92a0-4330-97c5-23a84a732fd7"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("79cfd9cf-0424-4126-bab2-581177c7b3ef"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("b40b8cff-c98f-469c-b78b-b13cdff6d25e"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("b8698048-bb61-47ac-8a52-0b9424061fb9"));

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("079ddd51-4279-453c-81af-b661e1a97f70"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("08ea9e93-ad99-4a50-8e38-5a16894a080a"),
                columns: new[] { "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), "Beginner", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("222ea40c-6ba4-4b8c-b5d4-8a65f7e0702e"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes" },
                values: new object[] { "Wellington's premier year-round surf beach, right beside the airport. Sand-bottomed peaks work for all levels at all times of year, with minimal localism — the friendliest lineup in the city. Fires best on calm mornings before the notorious afternoon northerly kicks in. Board hire and lessons available from the surf club.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2cb08af2-836e-4f5e-a7e2-14aa572b68c4"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2d8931ef-7b3c-480c-99c1-ac27f1f6df5f"),
                columns: new[] { "CurrentWaveSize", "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { "WaistHigh", new List<string> { "Bathrooms" }, "Beginner", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2e9d55ab-daf5-4141-94a2-d565db0db508"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2f3b5dc5-36a7-4069-a349-91ab4af657fc"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("37a14764-caad-42e5-8e6e-5240a8e9e378"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("4d237b3e-7a1f-4a45-9935-8913929c5a7e"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes" },
                values: new object[] { "A heavy point/reef break tucked below the Kaikoura mountains, named after the old freezing works nearby. Fast takeoffs into hollow sections over boulders and rocks — unpredictability increased post-2016 earthquake. Expert-only on larger swells; approach with local knowledge.", new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5461358c-f193-4e36-82a0-ad5da43909ae"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes", "WaveType" },
                values: new object[] { "Arguably Christchurch's single best surf spot — a right-hand point that peels from the headland over 100 metres into the bay, protected from easterlies by cliffs and a breakwater. Soft and mellow waves make it a longboarder's dream, while bigger winter swells bring out the performance surfers.", new List<string> { "Bathrooms", "Showers" }, new List<string> { "Longboard", "Shortboard", "Fish", "Funboard" }, "PointBreak" });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5471f752-5f17-44f9-b0fb-b5a5adfa07c6"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("56e492f5-04ad-42b4-8b90-0091f36685fc"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("57c0b8c7-6ecf-4cb8-8634-ce6da7b08d25"),
                columns: new[] { "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), "Beginner", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5b8a8775-d285-4c8d-b4c7-e9410f8cc698"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5de53267-9ae1-4c46-a3e8-3b7fcca20fd8"),
                columns: new[] { "CurrentWaveSize", "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { "WaistHigh", new List<string> { "Bathrooms", "Campground" }, "Beginner", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("674759a2-93b5-4946-aa2f-237b42c7466c"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes", "TypicalCrowd" },
                values: new object[] { "The jewel in Kaikoura's surf crown — a long, peeling left-to-right bay break that fills the whole bay with some of the longest rides this side of Raglan. Steady offshore winds, incredible mountain views, and consistent winter swells from the east make this one of the South Island's most celebrated waves.", new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Shortboard", "Fish" }, "Busy" });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("6dfb9b90-fbed-49fa-9bf4-26b6f64027e0"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Longboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("78edcc0a-476c-4bd1-83ad-0471284eb0bc"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("80bc2dbd-50b6-4396-94a1-bc73a1ef9192"),
                columns: new[] { "Facilities", "MinSkillLevel", "Region", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, "Beginner", "BayOfPlenty", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("82d57d3e-60a4-48b6-bb65-dfb072918add"),
                columns: new[] { "CurrentWaveSize", "Description", "Facilities", "MaxWaveSize", "MinSkillLevel", "MinWaveSize", "Name", "SuitableBoardTypes", "WaveType" },
                values: new object[] { "WaistHigh", "Christchurch's most popular surf beach, stretching north from the famous pier. Consistent beach break peaks on most swells, full facilities, and a surf club that runs lessons — the go-to spot for the city.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, "HeadHigh", "Beginner", "AnkleHigh", "New Brighton", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "BeachBreak" });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("83c3e03b-6c53-4d56-8459-e3b93e9c510f"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("88334bce-7cd9-42cd-8ae9-85f4bf2b71fc"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("96964eda-9754-4e3d-bf49-6a813e35f7f0"),
                columns: new[] { "Facilities", "Region", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, "BayOfPlenty", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("987dfab8-acc2-4dc1-b184-312374c9375d"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("99d031a1-bed7-44b3-8217-5089e335c396"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9aabf94d-fdaf-47e3-8616-e50123dd33c7"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9b283513-697e-4a41-aaf5-c9c1c4eacaff"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9eeb5861-d0bc-4cb9-84b3-f1174940ea7f"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes" },
                values: new object[] { "Beefy, strong, and occasionally rippable year-round beach break just north of Gisborne — most reliable from autumn to spring. At full tide the reef sections punch up. Stock Route, the short tubular runner on the south end, fires up on the right swell. One of the East Coast's most consistent waves.", new List<string> { "Bathrooms", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9fad49c3-00c3-46a1-893c-88349b410a41"),
                columns: new[] { "Facilities", "Region", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, "BayOfPlenty", new List<string> { "Rental", "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a369bf4f-1c77-4a5c-848c-f136d5b866c7"),
                columns: new[] { "CurrentWaveSize", "Description", "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { "WaistHigh", "Auckland's most powerful West Coast beach break, taking the full force of Tasman Sea swells. Sucky, punchy peaks reward experienced surfers — strong rips make it unsuitable for beginners. Check Maori Bay just around the headland for slightly more sheltered lefts and rights when Muriwai closes out.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "Beginner", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a539f8d9-e30b-43ef-be31-529f991693b9"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes" },
                values: new object[] { "Auckland's most iconic surf beach — one of the best on the North Island's West Coast. Sucky beach break with excellent lefts and rights off Lion Rock, set against dramatic black-sand cliffs. Heavy rips and powerful shore dump demand solid ocean experience; beginners should surf between the flags only.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a8de5b53-30d6-4558-a690-71bafa56acc0"),
                columns: new[] { "Facilities", "Region", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "BayOfPlenty", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("afe79384-de57-4288-bb89-362d08d3d6e4"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("c08fa569-6643-4842-b5a7-1349659a41cb"),
                columns: new[] { "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, "Beginner", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("d49fe9f4-6e17-4a0b-a907-c529aef18fba"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Lifeguard", "Campground" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("d972655c-fd80-48b2-a9d5-843e8dcbd153"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("df46bcbe-0ebc-4910-a112-1e3bc0471559"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("e28a0c71-4b34-4544-9f33-19c941bc1375"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("e2c7acb6-000e-4933-b2b5-5f2a26f2a335"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("e997bc0f-4267-423f-b018-300f2ab68238"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("f4a5d3ca-048d-4905-9a93-8cf92fabc2b9"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("f60b983b-9353-4387-9917-7c058735b7f6"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("fe120869-eb8b-4962-bf24-d9e83a3ef3fe"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes", "TypicalCrowd" },
                values: new object[] { "A cruisy right-hand cobblestone point just north of Gisborne — long, fat shoulders ideal for cruising and carving. Sister break to North Makorori Reef across the bay. Gets busy on good days but localism is rare for New Zealand; best on a solid SE swell with a light offshore.", new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Fish", "Shortboard" }, "Moderate" });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("ffbb6992-3993-4712-b693-41412ec1cb2c"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.InsertData(
                table: "surf_spots",
                columns: new[] { "Id", "CreatedAt", "CurrentWaveSize", "Description", "Facilities", "MaxWaveSize", "MinSkillLevel", "MinWaveSize", "Name", "Region", "SuitableBoardTypes", "TypicalCrowd", "WaveType" },
                values: new object[,]
                {
                    { new Guid("1c35bc8a-9789-42a4-9bd4-368f5c774ec7"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "The closest break to Kaikoura town — a convenient option when you only have an hour to spare. Fun peaks go left and right on medium-swell days, and there's enough whitewash on smaller days for beginners. Nothing special, but reliably rideable.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "AnkleHigh", "Gooch's Beach", "Kaikoura", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Moderate", "BeachBreak" },
                    { new Guid("25e8876b-5560-4052-9e23-8fa5bf034073"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A long stretch of sand north of New Brighton with peaky, mellow waves that punch up on winter swells. A good escape when New Brighton gets crowded — shifting sandbanks keep conditions varied, and a local surf school operates here through summer.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "AnkleHigh", "Waimairi Beach", "Christchurch", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Quiet", "BeachBreak" },
                    { new Guid("320f04de-34f7-4d2f-8a50-e6d079cf75ec"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A sheltered beach break south of Kaikoura town with low, easy-going waves ideal for novices. Protected from northerlies and shallow enough for foam boards — popular with surf schools on summer mornings. Arrive early to beat the crowds.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "AnkleHigh", "Okiwi Bay", "Kaikoura", new List<string> { "Rental", "Longboard", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("5adf6b95-f296-4cd0-9178-24f0e16587ec"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A long beachfront strip south of Mount Maunganui main beach where waves lump up over the sandbars with fast drop-ins both left and right. Forgiving sand bottom, fewer swimmers than the Mount, and reliable shape on most NE swells — a great training ground for improving intermediates.", new List<string> { "Bathrooms", "Showers" }, "HeadHigh", "Beginner", "WaistHigh", "Tay Street", "BayOfPlenty", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("6c44f559-d734-4cf1-9a78-beba7b07cf7f"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A longboarder's dream about an hour south of Christchurch — a left-hand point off a boulder-dotted beach that produces some of the longest rides in the Canterbury region. Gets busy on solid south swells; arrive early for a smaller lineup.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Magnet Bay", "Christchurch", new List<string> { "Longboard", "Fish", "Funboard" }, "Moderate", "PointBreak" },
                    { new Guid("6c8776eb-d2dc-485d-98dd-24558d15efc1"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A wild beach break beside the famous Pancake Rocks on the Paparoa coast. Raw Tasman Sea swells hit the black-sand beach with real power — almost never crowded, and the scenery is unlike anywhere else in New Zealand.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Beginner", "WaistHigh", "Punakaiki", "WestCoast", new List<string> { "Shortboard", "Fish", "Funboard" }, "Quiet", "BeachBreak" },
                    { new Guid("7c926dd3-e07d-496d-81d1-c4821e0546fb"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A beach and point break combo north of Kaikoura that improved noticeably after the 2016 earthquake. Best on bigger swells when both the beach and the point fill in — watch for the shallow shore break and stick to low tide on larger days. Dolphins are common.", new List<string>(), "DoubleOverhead", "Beginner", "WaistHigh", "Ward Beach", "Kaikoura", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("8e89b39f-4425-48ae-8a7b-4b0fc2313168"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A high-quality beach break southeast of Mount Maunganui that gets punchy and responsive on NE swells over two feet. Slightly fewer crowds than the Mount itself, a friendly local surf club with no localism, and fast shoulders on bigger sets. One of the Bay of Plenty's best-kept secrets.", new List<string> { "Bathrooms", "SurfClub" }, "DoubleOverhead", "Beginner", "WaistHigh", "Papamoa Beach", "BayOfPlenty", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" },
                    { new Guid("a69840d9-5d56-41f8-926b-efc39eb7363a"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "Heavy take-off and uber-fast hollow sections with seriously long rides. Two entry points: Outsides for those new to NZ lefts, Insides for the committed expert. Prized by locals and often considered the most rewarding of Raglan's three point breaks.", new List<string>(), "DoubleOverhead", "Advanced", "WaistHigh", "Indicators", "Waikato", new List<string> { "Shortboard", "Fish" }, "Moderate", "PointBreak" },
                    { new Guid("b428d363-06a3-42c1-bed6-4d6f50340717"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A peeling left-hand point at the entrance to Wellington Harbour, working best on strong southerly swells through the winter months. A quieter alternative to Lyall Bay with a more committed paddle out — watch for the SW crosswind that can make it choppy in the afternoon.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Pencarrow Head", "Wellington", new List<string> { "Shortboard", "Fish", "Longboard" }, "Quiet", "PointBreak" },
                    { new Guid("b9d233c7-01f7-48ba-b393-6ab66b91d936"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A consistent swell magnet about 35 minutes from Raglan town on black sand. Multiple peaks for all abilities on smaller days — shoulder-high and mellow at its best. A reliable alternative when Manu Bay and Whale Bay are too heavy.", new List<string>(), "HeadHigh", "Beginner", "KneeHigh", "Ruapuke Beach", "Waikato", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Quiet", "BeachBreak" },
                    { new Guid("bc88f11c-88ac-4fb1-ac5b-984488ff2800"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "The most accessible surf beach on the West Coast, right at the edge of Hokitika town. Consistent Tasman Sea swells break over dark sand with no crowds — the town's sunsets here are legendary, and the pounamu shops make the trip worthwhile rain or shine.", new List<string> { "Bathrooms", "SurfClub" }, "DoubleOverhead", "Beginner", "WaistHigh", "Hokitika Beach", "WestCoast", new List<string> { "Shortboard", "Fish", "Funboard" }, "Quiet", "BeachBreak" },
                    { new Guid("cde176c8-1e45-457b-9b30-c1fd73561ea5"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "An uber-fun, accessible beach south of Gisborne with a mellow peeler that sections into glassy walls and frothing whitewash. Both a left and right point wrap around the bay, catching refracted south swells that can be smaller and cleaner than Wainui. Good for all levels on most days.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "AnkleHigh", "Sponge Bay", "Gisborne", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Quiet", "BeachBreak" },
                    { new Guid("f06841b9-b3be-49db-82e9-8dec588e3207"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A dramatic south-facing bay in Wellington's western suburbs with a muscular right-hander point at its south end. A solid option when Lyall Bay is too crowded — the scenery is stunning and the waves have real character. Catches the same south swells as Lyall Bay.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "WaistHigh", "Houghton Bay", "Wellington", new List<string> { "Shortboard", "Fish", "Funboard" }, "Moderate", "BeachBreak" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("1c35bc8a-9789-42a4-9bd4-368f5c774ec7"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("25e8876b-5560-4052-9e23-8fa5bf034073"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("320f04de-34f7-4d2f-8a50-e6d079cf75ec"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5adf6b95-f296-4cd0-9178-24f0e16587ec"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("6c44f559-d734-4cf1-9a78-beba7b07cf7f"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("6c8776eb-d2dc-485d-98dd-24558d15efc1"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("7c926dd3-e07d-496d-81d1-c4821e0546fb"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("8e89b39f-4425-48ae-8a7b-4b0fc2313168"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a69840d9-5d56-41f8-926b-efc39eb7363a"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("b428d363-06a3-42c1-bed6-4d6f50340717"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("b9d233c7-01f7-48ba-b393-6ab66b91d936"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("bc88f11c-88ac-4fb1-ac5b-984488ff2800"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("cde176c8-1e45-457b-9b30-c1fd73561ea5"));

            migrationBuilder.DeleteData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("f06841b9-b3be-49db-82e9-8dec588e3207"));

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("079ddd51-4279-453c-81af-b661e1a97f70"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("08ea9e93-ad99-4a50-8e38-5a16894a080a"),
                columns: new[] { "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), "Intermediate", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("222ea40c-6ba4-4b8c-b5d4-8a65f7e0702e"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes" },
                values: new object[] { "Wellington's most accessible surf beach, right next to the airport. Consistent swell from Cook Strait makes it reliable year-round, though it fires best on calm mornings before the afternoon northerly kicks in.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2cb08af2-836e-4f5e-a7e2-14aa572b68c4"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2d8931ef-7b3c-480c-99c1-ac27f1f6df5f"),
                columns: new[] { "CurrentWaveSize", "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { "HeadHigh", new List<string> { "Bathrooms" }, "Intermediate", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2e9d55ab-daf5-4141-94a2-d565db0db508"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("2f3b5dc5-36a7-4069-a349-91ab4af657fc"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("37a14764-caad-42e5-8e6e-5240a8e9e378"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("4d237b3e-7a1f-4a45-9935-8913929c5a7e"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes" },
                values: new object[] { "A powerful left-hand reef break tucked below the Kaikoura mountains. Named after the old meatworks nearby — raw, heavy, and stunning when it's firing.", new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5461358c-f193-4e36-82a0-ad5da43909ae"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes", "WaveType" },
                values: new object[] { "Tucked beside Sumner, Scarborough picks up solid South Island swells and offers punchy beach break waves in a scenic setting.", new List<string> { "Bathrooms", "Showers" }, new List<string> { "Shortboard", "Fish", "Longboard" }, "BeachBreak" });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5471f752-5f17-44f9-b0fb-b5a5adfa07c6"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("56e492f5-04ad-42b4-8b90-0091f36685fc"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("57c0b8c7-6ecf-4cb8-8634-ce6da7b08d25"),
                columns: new[] { "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), "Intermediate", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5b8a8775-d285-4c8d-b4c7-e9410f8cc698"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5de53267-9ae1-4c46-a3e8-3b7fcca20fd8"),
                columns: new[] { "CurrentWaveSize", "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { "HeadHigh", new List<string> { "Bathrooms", "Campground" }, "Intermediate", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("674759a2-93b5-4946-aa2f-237b42c7466c"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes", "TypicalCrowd" },
                values: new object[] { "One of New Zealand's longest right-hand point breaks, walling for hundreds of metres along the Kaikoura coastline. A remote gem that makes the drive from Christchurch very worthwhile.", new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Shortboard", "Fish" }, "Quiet" });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("6dfb9b90-fbed-49fa-9bf4-26b6f64027e0"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Longboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("78edcc0a-476c-4bd1-83ad-0471284eb0bc"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("80bc2dbd-50b6-4396-94a1-bc73a1ef9192"),
                columns: new[] { "Facilities", "MinSkillLevel", "Region", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, "Intermediate", "Coromandel", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("82d57d3e-60a4-48b6-bb65-dfb072918add"),
                columns: new[] { "CurrentWaveSize", "Description", "Facilities", "MaxWaveSize", "MinSkillLevel", "MinWaveSize", "Name", "SuitableBoardTypes", "WaveType" },
                values: new object[] { "HeadHigh", "A sheltered cove on the Banks Peninsula, accessed via a winding hill road from Sumner. Offers both left and right reef peaks that are more protected from onshore winds than New Brighton — a favourite when the city beaches go messy.", new List<string> { "Bathrooms" }, "DoubleOverhead", "Intermediate", "WaistHigh", "Taylors Mistake", new List<string> { "Shortboard", "Fish", "Funboard" }, "ReefBreak" });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("83c3e03b-6c53-4d56-8459-e3b93e9c510f"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("88334bce-7cd9-42cd-8ae9-85f4bf2b71fc"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("96964eda-9754-4e3d-bf49-6a813e35f7f0"),
                columns: new[] { "Facilities", "Region", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, "Coromandel", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("987dfab8-acc2-4dc1-b184-312374c9375d"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("99d031a1-bed7-44b3-8217-5089e335c396"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9aabf94d-fdaf-47e3-8616-e50123dd33c7"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9b283513-697e-4a41-aaf5-c9c1c4eacaff"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9eeb5861-d0bc-4cb9-84b3-f1174940ea7f"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes" },
                values: new object[] { "A long sandy beach just north of Gisborne city with consistent beach break peaks. Popular with locals and a reliable option when the easterly swells arrive.", new List<string> { "Bathrooms", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9fad49c3-00c3-46a1-893c-88349b410a41"),
                columns: new[] { "Facilities", "Region", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, "Coromandel", new List<string> { "Rental", "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a369bf4f-1c77-4a5c-848c-f136d5b866c7"),
                columns: new[] { "CurrentWaveSize", "Description", "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { "HeadHigh", "Auckland's wild black-sand West Coast beach. Powerful and consistent with strong rips — rewarding for surfers with solid ocean awareness.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "Intermediate", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a539f8d9-e30b-43ef-be31-529f991693b9"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes" },
                values: new object[] { "Auckland's most famous surf beach — powerful, dramatic, and stunning. Heavy rips demand solid ocean experience before paddling out.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a8de5b53-30d6-4558-a690-71bafa56acc0"),
                columns: new[] { "Facilities", "Region", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, "Coromandel", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("afe79384-de57-4288-bb89-362d08d3d6e4"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("c08fa569-6643-4842-b5a7-1349659a41cb"),
                columns: new[] { "Facilities", "MinSkillLevel", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, "Intermediate", new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("d49fe9f4-6e17-4a0b-a907-c529aef18fba"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Lifeguard", "Campground" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("d972655c-fd80-48b2-a9d5-843e8dcbd153"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("df46bcbe-0ebc-4910-a112-1e3bc0471559"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("e28a0c71-4b34-4544-9f33-19c941bc1375"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("e2c7acb6-000e-4933-b2b5-5f2a26f2a335"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("e997bc0f-4267-423f-b018-300f2ab68238"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("f4a5d3ca-048d-4905-9a93-8cf92fabc2b9"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("f60b983b-9353-4387-9917-7c058735b7f6"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("fe120869-eb8b-4962-bf24-d9e83a3ef3fe"),
                columns: new[] { "Description", "Facilities", "SuitableBoardTypes", "TypicalCrowd" },
                values: new object[] { "A cobblestone right-hander just north of Gisborne. Quieter than the town beach with fun point break walls on a good swell.", new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Fish", "Shortboard" }, "Quiet" });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("ffbb6992-3993-4712-b693-41412ec1cb2c"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.InsertData(
                table: "surf_spots",
                columns: new[] { "Id", "CreatedAt", "CurrentWaveSize", "Description", "Facilities", "MaxWaveSize", "MinSkillLevel", "MinWaveSize", "Name", "Region", "SuitableBoardTypes", "TypicalCrowd", "WaveType" },
                values: new object[,]
                {
                    { new Guid("337ae4b8-aca6-46e8-a841-e9b99a5e3d92"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A sheltered bay north of Wellington in Porirua, offering some of the most consistent and manageable beach break on the lower North Island. The surf club is active, lifeguards patrol in summer, and the sand-bottom waves are kind to learners.", new List<string> { "Bathrooms", "SurfClub", "Lifeguard" }, "HeadHigh", "Beginner", "AnkleHigh", "Titahi Bay", "Wellington", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Moderate", "BeachBreak" },
                    { new Guid("3e820cf6-fcd6-4731-b8e3-25860248bc4f"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "WaistHigh", "A friendly beach break 15 km south of New Plymouth with a strong community surf club. Mellow rolling waves are perfect for learners and longboarders, and the campground makes it easy to stay and score multiple sessions.", new List<string> { "Bathrooms", "Showers", "SurfClub", "Campground" }, "HeadHigh", "Beginner", "AnkleHigh", "Oakura", "Taranaki", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" }, "Moderate", "BeachBreak" },
                    { new Guid("5252189f-a966-4a43-958f-f4a388883eff"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A semi-secret right-hander on Taranaki's Surf Highway 45 that peels along a rocky point with impressive length on a solid southerly swell. Known mainly to locals, it rewards those willing to hike a short distance from the road.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Komene Road", "Taranaki", new List<string> { "Shortboard", "Fish", "Longboard" }, "Quiet", "PointBreak" },
                    { new Guid("6206f692-1cb2-4133-8685-fdcabe0ec9fb"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "An exposed and remote shingle-beach break at the southern tip of the Wairarapa. Punishing shore-dump sections between powerful peaks make this strictly for experienced surfers — the reward is almost complete solitude and serious South Coast power.", new List<string>(), "DoubleOverhead", "Advanced", "HeadHigh", "Palliser Bay", "Wellington", new List<string> { "Shortboard", "Fish" }, "Quiet", "BeachBreak" },
                    { new Guid("755ff886-92a0-4330-97c5-23a84a732fd7"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A wide open beach break stretching north from the Waimakariri River mouth. Rarely crowded and produces gentle, forgiving waves on smaller swells — popular for learners and those wanting a session away from the Sumner crowds.", new List<string> { "Bathrooms" }, "HeadHigh", "Beginner", "AnkleHigh", "Pegasus Bay", "Christchurch", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Quiet", "BeachBreak" },
                    { new Guid("79cfd9cf-0424-4126-bab2-581177c7b3ef"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A quality right-hand reef point just north of Gisborne. Long, walling walls peel along a rock shelf and produce some of the most consistent point-break action on the East Coast — often offshore when inland areas are cross-shore.", new List<string>(), "DoubleOverhead", "Intermediate", "WaistHigh", "Tatapouri", "Gisborne", new List<string> { "Shortboard", "Fish", "Longboard" }, "Quiet", "ReefBreak" },
                    { new Guid("b40b8cff-c98f-469c-b78b-b13cdff6d25e"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "HeadHigh", "A powerful reef break north of Kaikoura accessible only by walking along the rail corridor at low tide. Heavy, hollow waves break over a shallow ledge — for experienced surfers only and best surfed with a local guide.", new List<string>(), "DoubleOverhead", "Advanced", "HeadHigh", "Haumuri Bluffs", "Kaikoura", new List<string> { "Shortboard", "Fish" }, "Quiet", "ReefBreak" },
                    { new Guid("b8698048-bb61-47ac-8a52-0b9424061fb9"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "KneeHigh", "A peaceful and seldom-visited beach break north of Gisborne with gentle, beginner-friendly waves on most swells. The lack of facilities and crowds makes it ideal for a quiet dawn patrol or an uncrowded afternoon session.", new List<string>(), "HeadHigh", "Beginner", "AnkleHigh", "Pouawa", "Gisborne", new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" }, "Quiet", "BeachBreak" }
                });
        }
    }
}
