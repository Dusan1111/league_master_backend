using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StatusAddedToCompetitionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRounds",
                table: "Leagues");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRounds",
                table: "SesasonLeagues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberPlayOffRounds",
                table: "SesasonLeagues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SesasonLeagues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRounds",
                table: "SesasonLeagues");

            migrationBuilder.DropColumn(
                name: "NumberPlayOffRounds",
                table: "SesasonLeagues");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SesasonLeagues");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRounds",
                table: "Leagues",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
