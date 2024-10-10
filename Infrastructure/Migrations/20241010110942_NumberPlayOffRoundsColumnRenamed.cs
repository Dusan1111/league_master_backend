using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NumberPlayOffRoundsColumnRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberPlayOffRounds",
                table: "SesasonLeagues",
                newName: "NumberOfPlayOffRounds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfPlayOffRounds",
                table: "SesasonLeagues",
                newName: "NumberPlayOffRounds");
        }
    }
}
