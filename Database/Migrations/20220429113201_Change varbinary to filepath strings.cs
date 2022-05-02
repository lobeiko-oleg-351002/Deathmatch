using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Changevarbinarytofilepathstrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Binaries",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "LevelFilepath",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PosterFilepath",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelFilepath",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "PosterFilepath",
                table: "Locations");

            migrationBuilder.AddColumn<byte[]>(
                name: "Binaries",
                table: "Locations",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Poster",
                table: "Locations",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
