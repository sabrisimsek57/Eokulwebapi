using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eokulwebapi.Migrations
{
    public partial class mig05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Görevi",
                table: "Öğretmens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sıra",
                table: "Öğretmens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Görevi",
                table: "Öğretmens");

            migrationBuilder.DropColumn(
                name: "Sıra",
                table: "Öğretmens");
        }
    }
}
