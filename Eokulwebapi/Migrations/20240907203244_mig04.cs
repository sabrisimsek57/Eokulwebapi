using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eokulwebapi.Migrations
{
    public partial class mig04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Öğretmens",
                columns: table => new
                {
                    ÖğretmenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branş = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Öğretmens", x => x.ÖğretmenId);
                });

            migrationBuilder.CreateTable(
                name: "Ders",
                columns: table => new
                {
                    DersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersKod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DersAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HD_Sırası = table.Column<int>(type: "int", nullable: false),
                    ÖğretmenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ders", x => x.DersId);
                    table.ForeignKey(
                        name: "FK_Ders_Öğretmens_ÖğretmenId",
                        column: x => x.ÖğretmenId,
                        principalTable: "Öğretmens",
                        principalColumn: "ÖğretmenId");
                });

            migrationBuilder.CreateTable(
                name: "dersProgramıs",
                columns: table => new
                {
                    DersProgramıId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SınıfId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false),
                    Gün = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KaçıncıDers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dersProgramıs", x => x.DersProgramıId);
                    table.ForeignKey(
                        name: "FK_dersProgramıs_Ders_DersId",
                        column: x => x.DersId,
                        principalTable: "Ders",
                        principalColumn: "DersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dersProgramıs_Sınıfs_SınıfId",
                        column: x => x.SınıfId,
                        principalTable: "Sınıfs",
                        principalColumn: "SınıfId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ders_ÖğretmenId",
                table: "Ders",
                column: "ÖğretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_dersProgramıs_DersId",
                table: "dersProgramıs",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_dersProgramıs_SınıfId",
                table: "dersProgramıs",
                column: "SınıfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dersProgramıs");

            migrationBuilder.DropTable(
                name: "Ders");

            migrationBuilder.DropTable(
                name: "Öğretmens");
        }
    }
}
