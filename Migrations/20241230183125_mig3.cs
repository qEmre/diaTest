using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace diaTest.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "BelgeNo",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "CariFirmaAdi",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "FaturaAdresi",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "SevkAdresi",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Fatura");

            migrationBuilder.AlterColumn<decimal>(
                name: "ToplamKdv",
                table: "Fatura",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Toplam",
                table: "Fatura",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Key",
                table: "Fatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CariKartAdresiId",
                table: "Fatura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CariKartId",
                table: "Fatura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CariKart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<int>(type: "int", nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariKart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CariKartAdresi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<int>(type: "int", nullable: false),
                    Adres1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariKartAdresi", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_CariKartAdresiId",
                table: "Fatura",
                column: "CariKartAdresiId");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_CariKartId",
                table: "Fatura",
                column: "CariKartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_CariKartAdresi_CariKartAdresiId",
                table: "Fatura",
                column: "CariKartAdresiId",
                principalTable: "CariKartAdresi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_CariKart_CariKartId",
                table: "Fatura",
                column: "CariKartId",
                principalTable: "CariKart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_CariKartAdresi_CariKartAdresiId",
                table: "Fatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_CariKart_CariKartId",
                table: "Fatura");

            migrationBuilder.DropTable(
                name: "CariKart");

            migrationBuilder.DropTable(
                name: "CariKartAdresi");

            migrationBuilder.DropIndex(
                name: "IX_Fatura_CariKartAdresiId",
                table: "Fatura");

            migrationBuilder.DropIndex(
                name: "IX_Fatura_CariKartId",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "CariKartAdresiId",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "CariKartId",
                table: "Fatura");

            migrationBuilder.AlterColumn<string>(
                name: "ToplamKdv",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Toplam",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BelgeNo",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CariFirmaAdi",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FaturaAdresi",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SevkAdresi",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
