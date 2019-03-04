using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_DB_Layer.Migrations
{
    public partial class Modified0103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Challenges_ChallengeId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationType",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Sport",
                table: "Fields");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStart",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeEnd",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeId",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsChallenge",
                table: "Reservations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDouble",
                table: "Reservations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Players",
                table: "Fields",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSeven",
                table: "Fields",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Challenges_ChallengeId",
                table: "Reservations",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "ChallengeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Challenges_ChallengeId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsChallenge",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsDouble",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Players",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "IsSeven",
                table: "Fields");

            migrationBuilder.AlterColumn<string>(
                name: "TimeStart",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "TimeEnd",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeId",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ReservationType",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sport",
                table: "Fields",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Challenges_ChallengeId",
                table: "Reservations",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "ChallengeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
