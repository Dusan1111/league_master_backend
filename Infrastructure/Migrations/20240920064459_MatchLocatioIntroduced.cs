using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MatchLocatioIntroduced : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Standings_Teams_TeamId",
                table: "Standings");

            migrationBuilder.DropIndex(
                name: "IX_Standings_TeamId",
                table: "Standings");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Standings");

            migrationBuilder.AddColumn<int>(
                name: "StandingId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchLocationId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MatchLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchLocation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StandingId",
                table: "Teams",
                column: "StandingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchLocationId",
                table: "Matches",
                column: "MatchLocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchLocation_MatchLocationId",
                table: "Matches",
                column: "MatchLocationId",
                principalTable: "MatchLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Standings_StandingId",
                table: "Teams",
                column: "StandingId",
                principalTable: "Standings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchLocation_MatchLocationId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Standings_StandingId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "MatchLocation");

            migrationBuilder.DropIndex(
                name: "IX_Teams_StandingId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Matches_MatchLocationId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "StandingId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "MatchLocationId",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Standings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Standings_TeamId",
                table: "Standings",
                column: "TeamId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Standings_Teams_TeamId",
                table: "Standings",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
