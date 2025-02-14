using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eokulwebapi.Migrations
{
    public partial class mig15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ÖğretmenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ÖğretmenId",
                table: "AspNetUsers",
                column: "ÖğretmenId",
                unique: true,
                filter: "[ÖğretmenId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Öğretmens_ÖğretmenId",
                table: "AspNetUsers",
                column: "ÖğretmenId",
                principalTable: "Öğretmens",
                principalColumn: "ÖğretmenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Öğretmens_ÖğretmenId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ÖğretmenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ÖğretmenId",
                table: "AspNetUsers");
        }
    }
}
