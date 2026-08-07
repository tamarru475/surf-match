using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class MultiRegionSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreferredRegion",
                table: "user_preferences");

            migrationBuilder.AddColumn<List<string>>(
                name: "PreferredRegions",
                table: "user_preferences",
                type: "text[]",
                nullable: false,
                defaultValueSql: "'{}'::text[]");

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("1c35bc8a-9789-42a4-9bd4-368f5c774ec7"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("222ea40c-6ba4-4b8c-b5d4-8a65f7e0702e"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("25e8876b-5560-4052-9e23-8fa5bf034073"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

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
                keyValue: new Guid("320f04de-34f7-4d2f-8a50-e6d079cf75ec"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Rental", "Longboard", "Funboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5461358c-f193-4e36-82a0-ad5da43909ae"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Longboard", "Shortboard", "Fish", "Funboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5adf6b95-f296-4cd0-9178-24f0e16587ec"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("674759a2-93b5-4946-aa2f-237b42c7466c"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("6c44f559-d734-4cf1-9a78-beba7b07cf7f"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Longboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("6c8776eb-d2dc-485d-98dd-24558d15efc1"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

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
                keyValue: new Guid("7c926dd3-e07d-496d-81d1-c4821e0546fb"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("80bc2dbd-50b6-4396-94a1-bc73a1ef9192"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("82d57d3e-60a4-48b6-bb65-dfb072918add"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

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
                keyValue: new Guid("8e89b39f-4425-48ae-8a7b-4b0fc2313168"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("96964eda-9754-4e3d-bf49-6a813e35f7f0"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9fad49c3-00c3-46a1-893c-88349b410a41"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a369bf4f-1c77-4a5c-848c-f136d5b866c7"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a539f8d9-e30b-43ef-be31-529f991693b9"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a69840d9-5d56-41f8-926b-efc39eb7363a"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a8de5b53-30d6-4558-a690-71bafa56acc0"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("afe79384-de57-4288-bb89-362d08d3d6e4"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("b428d363-06a3-42c1-bed6-4d6f50340717"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("b9d233c7-01f7-48ba-b393-6ab66b91d936"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("bc88f11c-88ac-4fb1-ac5b-984488ff2800"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("c08fa569-6643-4842-b5a7-1349659a41cb"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("cde176c8-1e45-457b-9b30-c1fd73561ea5"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

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
                keyValue: new Guid("f06841b9-b3be-49db-82e9-8dec588e3207"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("ffbb6992-3993-4712-b693-41412ec1cb2c"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish" } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreferredRegions",
                table: "user_preferences");

            migrationBuilder.AddColumn<string>(
                name: "PreferredRegion",
                table: "user_preferences",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("1c35bc8a-9789-42a4-9bd4-368f5c774ec7"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("222ea40c-6ba4-4b8c-b5d4-8a65f7e0702e"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("25e8876b-5560-4052-9e23-8fa5bf034073"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

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
                keyValue: new Guid("320f04de-34f7-4d2f-8a50-e6d079cf75ec"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Rental", "Longboard", "Funboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5461358c-f193-4e36-82a0-ad5da43909ae"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Longboard", "Shortboard", "Fish", "Funboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("5adf6b95-f296-4cd0-9178-24f0e16587ec"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("674759a2-93b5-4946-aa2f-237b42c7466c"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("6c44f559-d734-4cf1-9a78-beba7b07cf7f"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Longboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("6c8776eb-d2dc-485d-98dd-24558d15efc1"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

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
                keyValue: new Guid("7c926dd3-e07d-496d-81d1-c4821e0546fb"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("80bc2dbd-50b6-4396-94a1-bc73a1ef9192"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("82d57d3e-60a4-48b6-bb65-dfb072918add"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

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
                keyValue: new Guid("8e89b39f-4425-48ae-8a7b-4b0fc2313168"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("96964eda-9754-4e3d-bf49-6a813e35f7f0"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("9fad49c3-00c3-46a1-893c-88349b410a41"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a369bf4f-1c77-4a5c-848c-f136d5b866c7"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a539f8d9-e30b-43ef-be31-529f991693b9"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a69840d9-5d56-41f8-926b-efc39eb7363a"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("a8de5b53-30d6-4558-a690-71bafa56acc0"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("afe79384-de57-4288-bb89-362d08d3d6e4"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("b428d363-06a3-42c1-bed6-4d6f50340717"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("b9d233c7-01f7-48ba-b393-6ab66b91d936"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("bc88f11c-88ac-4fb1-ac5b-984488ff2800"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("c08fa569-6643-4842-b5a7-1349659a41cb"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("cde176c8-1e45-457b-9b30-c1fd73561ea5"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

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
                keyValue: new Guid("f06841b9-b3be-49db-82e9-8dec588e3207"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

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
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("ffbb6992-3993-4712-b693-41412ec1cb2c"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish" } });
        }
    }
}
