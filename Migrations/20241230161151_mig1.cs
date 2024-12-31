using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace diaTest.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CariTablo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CariAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DovizTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiDairesi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariTablo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaturaTablo",
                columns: table => new
                {
                    FaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DovizTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CariVergiNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CariVergiDairesi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CariFirma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SevkAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplamMiktar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Toplam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplamKdv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DovizKuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FisNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplamDoviz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetDoviz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BekleyenTutar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplamPara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplamParaDoviz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KalanTaksitTutar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaturaSecretKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CariId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaTablo", x => x.FaturaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CariTablo");

            migrationBuilder.DropTable(
                name: "FaturaTablo");
        }
    }
}
