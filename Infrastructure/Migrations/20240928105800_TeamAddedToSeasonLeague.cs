using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TeamAddedToSeasonLeague : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeasonLeagues_Teams_TeamId",
                table: "SeasonLeagues");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "SeasonLeagues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SeasonLeagues_Teams_TeamId",
                table: "SeasonLeagues",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeasonLeagues_Teams_TeamId",
                table: "SeasonLeagues");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "SeasonLeagues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SeasonLeagues_Teams_TeamId",
                table: "SeasonLeagues",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
