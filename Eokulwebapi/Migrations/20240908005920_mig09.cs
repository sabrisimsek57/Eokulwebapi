using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eokulwebapi.Migrations
{
    public partial class mig09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devamsızlıks",
                columns: table => new
                {
                    DevamsızlıkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ÖğrenciId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RaporluMu = table.Column<bool>(type: "bit", nullable: false),
                    NöbetçiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devamsızlıks", x => x.DevamsızlıkId);
                    table.ForeignKey(
                        name: "FK_Devamsızlıks_Öğrencis_ÖğrenciId",
                        column: x => x.ÖğrenciId,
                        principalTable: "Öğrencis",
                        principalColumn: "ÖğrenciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devamsızlıks_ÖğrenciId",
                table: "Devamsızlıks",
                column: "ÖğrenciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devamsızlıks");
        }
    }
}
