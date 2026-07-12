using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUserLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Lifeguard", "Campground" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "users");

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Rentals", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Longboard", "Funboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Lifeguard" }, new List<string> { "Rental", "Longboard", "Funboard", "Fish", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms" }, new List<string> { "Longboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Longboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "Lifeguard", "Campground" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Campground" }, new List<string> { "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string>(), new List<string> { "Shortboard", "Fish", "Funboard" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "Showers", "SurfClub", "Lifeguard", "Rentals" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard", "Fish" } });

            migrationBuilder.UpdateData(
                table: "surf_spots",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "Facilities", "SuitableBoardTypes" },
                values: new object[] { new List<string> { "Bathrooms", "SurfClub" }, new List<string> { "Rental", "Longboard", "Funboard", "Shortboard" } });
        }
    }
}
