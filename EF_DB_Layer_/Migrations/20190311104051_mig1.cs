using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_DB_Layer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Challenges_ChallengeId1",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ChallengeId1",
                table: "Users",
                newName: "ChallengeId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ChallengeId1",
                table: "Users",
                newName: "IX_Users_ChallengeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Challenges_ChallengeId",
                table: "Users",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "ChallengeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Challenges_ChallengeId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ChallengeId",
                table: "Users",
                newName: "ChallengeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ChallengeId",
                table: "Users",
                newName: "IX_Users_ChallengeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Challenges_ChallengeId1",
                table: "Users",
                column: "ChallengeId1",
                principalTable: "Challenges",
                principalColumn: "ChallengeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
