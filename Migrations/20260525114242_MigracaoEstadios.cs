using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CopaHAS.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoEstadios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Posicao",
                table: "TB_JOGADORES",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_JOGADORES",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_ESTADIO",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "TB_ESTADIO",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Capacidade",
                table: "TB_ESTADIO",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "TB_JOGOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_JOGOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_JOGOS_TB_ESTADIO_EstadioId",
                        column: x => x.EstadioId,
                        principalTable: "TB_ESTADIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_SELECOES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SELECOES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_JOGOS_SELECOES",
                columns: table => new
                {
                    JogoId = table.Column<int>(type: "int", nullable: false),
                    SelecaoId = table.Column<int>(type: "int", nullable: false),
                    Gols = table.Column<int>(type: "int", nullable: false),
                    GolsProrrogacao = table.Column<int>(type: "int", nullable: false),
                    GolsDecisaoPenaltis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_JOGOS_SELECOES", x => new { x.JogoId, x.SelecaoId });
                    table.ForeignKey(
                        name: "FK_TB_JOGOS_SELECOES_TB_JOGOS_JogoId",
                        column: x => x.JogoId,
                        principalTable: "TB_JOGOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_JOGOS_SELECOES_TB_SELECOES_SelecaoId",
                        column: x => x.SelecaoId,
                        principalTable: "TB_SELECOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TECNICOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    SelecaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TECNICOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TECNICOS_TB_SELECOES_SelecaoId",
                        column: x => x.SelecaoId,
                        principalTable: "TB_SELECOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 82500m, "East Rutherford (NY/NJ)", "MetLife Stadium" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 70240m, "Los Angeles (CA)", "SoFi Stadium" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 80000m, "Arlington (TX)", "AT&T Stadium" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 71000m, "Atlanta (GA)", "Mercedes-Benz Stadium" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 72220m, "Houston (TX)", "NRG Stadium" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 68500m, "Santa Clara (CA)", "Levi's Stadium" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 68740m, "Seattle (WA)", "Lumen Field" });

            migrationBuilder.InsertData(
                table: "TB_ESTADIO",
                columns: new[] { "Id", "Capacidade", "Cidade", "Nome" },
                values: new object[,]
                {
                    { 8, 69596m, "Philadelphia (PA)", "Lincoln Financial Field" },
                    { 9, 65326m, "Miami (FL)", "Hard Rock Stadium" },
                    { 10, 76416m, "Kansas City (MO)", "GEHA Field at Arrowhead Stadium" },
                    { 11, 65878m, "Foxborough (MA)", "Gillette Stadium" },
                    { 12, 54500m, "Vancouver", "BC Place" },
                    { 13, 30000m, "Toronto", "BMO Field" },
                    { 14, 87000m, "Cidade do México", "Estadio Azteca" },
                    { 15, 53500m, "Monterrey", "Estadio BBVA" },
                    { 16, 49850m, "Guadalajara", "Estadio Akron" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGADORES_SelecaoId",
                table: "TB_JOGADORES",
                column: "SelecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGOS_EstadioId",
                table: "TB_JOGOS",
                column: "EstadioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGOS_SELECOES_SelecaoId",
                table: "TB_JOGOS_SELECOES",
                column: "SelecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TECNICOS_SelecaoId",
                table: "TB_TECNICOS",
                column: "SelecaoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_JOGADORES_TB_SELECOES_SelecaoId",
                table: "TB_JOGADORES",
                column: "SelecaoId",
                principalTable: "TB_SELECOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_JOGADORES_TB_SELECOES_SelecaoId",
                table: "TB_JOGADORES");

            migrationBuilder.DropTable(
                name: "TB_JOGOS_SELECOES");

            migrationBuilder.DropTable(
                name: "TB_TECNICOS");

            migrationBuilder.DropTable(
                name: "TB_JOGOS");

            migrationBuilder.DropTable(
                name: "TB_SELECOES");

            migrationBuilder.DropIndex(
                name: "IX_TB_JOGADORES_SelecaoId",
                table: "TB_JOGADORES");

            migrationBuilder.DeleteData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Posicao",
                table: "TB_JOGADORES",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_JOGADORES",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_ESTADIO",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "TB_ESTADIO",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacidade",
                table: "TB_ESTADIO",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 2000, "Cidadezona", "Estadio1" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 1200, "Cidade", "Estadio2" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 3100, "Osasco", "Estadio3" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 8000, "Itaquaquecetuba", "Estadio4" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 1300, "Itapevi", "Estadio5" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 6700, "Guarulhos", "Estadio6" });

            migrationBuilder.UpdateData(
                table: "TB_ESTADIO",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Capacidade", "Cidade", "Nome" },
                values: new object[] { 12000, "São Paulo", "Estadio7" });
        }
    }
}
