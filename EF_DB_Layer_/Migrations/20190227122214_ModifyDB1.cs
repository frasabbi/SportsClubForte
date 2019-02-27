using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_DB_Layer.Migrations
{
    public partial class ModifyDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sports",
                table: "Fields",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Sport",
                table: "Fields",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sport",
                table: "Fields");

            migrationBuilder.AlterColumn<string>(
                name: "Sports",
                table: "Fields",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
