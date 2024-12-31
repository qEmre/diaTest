using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace diaTest.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CariFirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaturaAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SevkAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BelgeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Toplam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplamKdv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fatura");
        }
    }
}
