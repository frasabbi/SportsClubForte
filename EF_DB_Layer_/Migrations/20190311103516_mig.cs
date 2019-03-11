using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_DB_Layer.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Challenges_ChallengeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ChallengeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ChallengeId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChallengeId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChallengeId",
                table: "Users",
                column: "ChallengeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Challenges_ChallengeId",
                table: "Users",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "ChallengeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
