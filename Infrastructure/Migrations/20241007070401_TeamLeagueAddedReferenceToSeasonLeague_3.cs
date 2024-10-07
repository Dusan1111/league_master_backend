using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TeamLeagueAddedReferenceToSeasonLeague_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TeamLeagues_SeasonLeagueId",
                table: "TeamLeagues",
                column: "SeasonLeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamLeagues_SesasonLeagues_SeasonLeagueId",
                table: "TeamLeagues",
                column: "SeasonLeagueId",
                principalTable: "SesasonLeagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamLeagues_SesasonLeagues_SeasonLeagueId",
                table: "TeamLeagues");

            migrationBuilder.DropIndex(
                name: "IX_TeamLeagues_SeasonLeagueId",
                table: "TeamLeagues");
        }
    }
}
