using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eokulwebapi.Migrations
{
    public partial class mig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ÖnKayıtÖğrencis",
                columns: table => new
                {
                    ÖnkayıtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ÖğrenciAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ÖğrenciSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BitirdiğiOkul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotOrtalamsı = table.Column<double>(type: "float", nullable: false),
                    VeliAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VeliSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvTelefonu = table.Column<int>(type: "int", nullable: false),
                    İşTelefonu = table.Column<int>(type: "int", nullable: false),
                    EvAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İlçe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ÖnKayıtÖğrencis", x => x.ÖnkayıtId);
                });

            migrationBuilder.CreateTable(
                name: "Sınıfs",
                columns: table => new
                {
                    SınıfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SınıfAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Şubesi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sınıfs", x => x.SınıfId);
                });

            migrationBuilder.CreateTable(
                name: "Öğrencis",
                columns: table => new
                {
                    ÖğrenciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkulNumarası = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DevamDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ÖnKayıtId = table.Column<int>(type: "int", nullable: false),
                    SınıfId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Öğrencis", x => x.ÖğrenciId);
                    table.ForeignKey(
                        name: "FK_Öğrencis_ÖnKayıtÖğrencis_ÖnKayıtId",
                        column: x => x.ÖnKayıtId,
                        principalTable: "ÖnKayıtÖğrencis",
                        principalColumn: "ÖnkayıtId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Öğrencis_Sınıfs_SınıfId",
                        column: x => x.SınıfId,
                        principalTable: "Sınıfs",
                        principalColumn: "SınıfId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Öğrencis_ÖnKayıtId",
                table: "Öğrencis",
                column: "ÖnKayıtId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Öğrencis_SınıfId",
                table: "Öğrencis",
                column: "SınıfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Öğrencis");

            migrationBuilder.DropTable(
                name: "ÖnKayıtÖğrencis");

            migrationBuilder.DropTable(
                name: "Sınıfs");
        }
    }
}
