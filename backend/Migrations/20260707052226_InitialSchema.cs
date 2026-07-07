using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "surf_spots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    WaveType = table.Column<string>(type: "text", nullable: false),
                    MinSkillLevel = table.Column<string>(type: "text", nullable: false),
                    SuitableBoardTypes = table.Column<List<string>>(type: "text[]", nullable: false),
                    Facilities = table.Column<List<string>>(type: "text[]", nullable: false),
                    TypicalCrowd = table.Column<string>(type: "text", nullable: false),
                    MinWaveSize = table.Column<string>(type: "text", nullable: false),
                    MaxWaveSize = table.Column<string>(type: "text", nullable: false),
                    CurrentWaveSize = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surf_spots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    InstagramHandle = table.Column<string>(type: "text", nullable: true),
                    TikTokHandle = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpotId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_favorites_surf_spots_SpotId",
                        column: x => x.SpotId,
                        principalTable: "surf_spots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favorites_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "surf_sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpotId = table.Column<Guid>(type: "uuid", nullable: false),
                    SurfedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surf_sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_surf_sessions_surf_spots_SpotId",
                        column: x => x.SpotId,
                        principalTable: "surf_spots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_surf_sessions_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_preferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillLevel = table.Column<string>(type: "text", nullable: false),
                    CrowdTolerance = table.Column<string>(type: "text", nullable: false),
                    PreferredRegion = table.Column<string>(type: "text", nullable: true),
                    BoardTypes = table.Column<List<string>>(type: "text[]", nullable: false),
                    PreferredWaveTypes = table.Column<List<string>>(type: "text[]", nullable: false),
                    PreferredWaveSizes = table.Column<List<string>>(type: "text[]", nullable: false),
                    PreferredFacilities = table.Column<List<string>>(type: "text[]", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_preferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_preferences_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_favorites_SpotId",
                table: "favorites",
                column: "SpotId");

            migrationBuilder.CreateIndex(
                name: "IX_favorites_UserId_SpotId",
                table: "favorites",
                columns: new[] { "UserId", "SpotId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_surf_sessions_SpotId",
                table: "surf_sessions",
                column: "SpotId");

            migrationBuilder.CreateIndex(
                name: "IX_surf_sessions_UserId",
                table: "surf_sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_preferences_UserId",
                table: "user_preferences",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "surf_sessions");

            migrationBuilder.DropTable(
                name: "user_preferences");

            migrationBuilder.DropTable(
                name: "surf_spots");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
