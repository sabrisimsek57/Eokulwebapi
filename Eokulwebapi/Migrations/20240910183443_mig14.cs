using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eokulwebapi.Migrations
{
    public partial class mig14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ÖğrenciId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ÖğrenciId",
                table: "AspNetUsers",
                column: "ÖğrenciId",
                unique: true,
                filter: "[ÖğrenciId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Öğrencis_ÖğrenciId",
                table: "AspNetUsers",
                column: "ÖğrenciId",
                principalTable: "Öğrencis",
                principalColumn: "ÖğrenciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Öğrencis_ÖğrenciId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ÖğrenciId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ÖğrenciId",
                table: "AspNetUsers");
        }
    }
}
