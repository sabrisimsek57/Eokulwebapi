using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eokulwebapi.Migrations
{
    public partial class mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "İlişkisiKesilens",
                columns: table => new
                {
                    İlişkisiKesilenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ÖğrenciId = table.Column<int>(type: "int", nullable: false),
                    İlişkisiKesilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gerekçe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İlişkisiKesilens", x => x.İlişkisiKesilenId);
                    table.ForeignKey(
                        name: "FK_İlişkisiKesilens_Öğrencis_ÖğrenciId",
                        column: x => x.ÖğrenciId,
                        principalTable: "Öğrencis",
                        principalColumn: "ÖğrenciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_İlişkisiKesilens_ÖğrenciId",
                table: "İlişkisiKesilens",
                column: "ÖğrenciId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "İlişkisiKesilens");
        }
    }
}
