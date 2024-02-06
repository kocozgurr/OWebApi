using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstimTeknoparkApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "firmalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyProperty = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Bina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YetkiliAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YetkiliSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSitesi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hakkında = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YetkiliTC = table.Column<int>(type: "int", nullable: false),
                    Sifre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firmalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "haberler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Başlık = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Slider = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_haberler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "salonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kisi = table.Column<int>(type: "int", nullable: false),
                    Konum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopsalFoto = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salonlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rezervasyonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cay = table.Column<int>(type: "int", nullable: false),
                    Kahve = table.Column<int>(type: "int", nullable: false),
                    EkTalep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tgbFirmaId = table.Column<int>(type: "int", nullable: false),
                    ToplantıSalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervasyonlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rezervasyonlar_firmalar_tgbFirmaId",
                        column: x => x.tgbFirmaId,
                        principalTable: "firmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rezervasyonlar_salonlar_ToplantıSalonId",
                        column: x => x.ToplantıSalonId,
                        principalTable: "salonlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rezervasyonlar_tgbFirmaId",
                table: "rezervasyonlar",
                column: "tgbFirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_rezervasyonlar_ToplantıSalonId",
                table: "rezervasyonlar",
                column: "ToplantıSalonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "haberler");

            migrationBuilder.DropTable(
                name: "rezervasyonlar");

            migrationBuilder.DropTable(
                name: "firmalar");

            migrationBuilder.DropTable(
                name: "salonlar");
        }
    }
}
