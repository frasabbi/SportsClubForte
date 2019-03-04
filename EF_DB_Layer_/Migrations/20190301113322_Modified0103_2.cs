using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_DB_Layer.Migrations
{
    public partial class Modified0103_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Challenges_ChallengeId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ChallengeId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ChallengeId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Challenges",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ReservationId",
                table: "Challenges",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_Reservations_ReservationId",
                table: "Challenges",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_Reservations_ReservationId",
                table: "Challenges");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_ReservationId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Challenges");

            migrationBuilder.AddColumn<int>(
                name: "ChallengeId",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ChallengeId",
                table: "Reservations",
                column: "ChallengeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Challenges_ChallengeId",
                table: "Reservations",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "ChallengeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
