using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CopaHAS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ESTADIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Capacidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESTADIO", x => x.Id);
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
                name: "TB_JOGADORES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NumeroCamisa = table.Column<int>(type: "int", nullable: false),
                    Posicao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SelecaoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_JOGADORES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_JOGADORES_TB_SELECOES_SelecaoId",
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

            migrationBuilder.InsertData(
                table: "TB_ESTADIO",
                columns: new[] { "Id", "Capacidade", "Cidade", "Nome" },
                values: new object[,]
                {
                    { 1, 82500m, "East Rutherford (NY/NJ)", "MetLife Stadium" },
                    { 2, 70240m, "Los Angeles (CA)", "SoFi Stadium" },
                    { 3, 80000m, "Arlington (TX)", "AT&T Stadium" },
                    { 4, 71000m, "Atlanta (GA)", "Mercedes-Benz Stadium" },
                    { 5, 72220m, "Houston (TX)", "NRG Stadium" },
                    { 6, 68500m, "Santa Clara (CA)", "Levi's Stadium" },
                    { 7, 68740m, "Seattle (WA)", "Lumen Field" },
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

            migrationBuilder.InsertData(
                table: "TB_JOGADORES",
                columns: new[] { "Id", "Nome", "NumeroCamisa", "Posicao", "SelecaoId", "Status" },
                values: new object[,]
                {
                    { 1, "Hugo Souza", 1, "Goleiro", 0, 1 },
                    { 2, "Yuri Alberto", 9, "Atacante", 0, 1 },
                    { 3, "Danilo", 2, "Lateral Direito", 0, 1 },
                    { 4, "Marquinhos", 4, "Zagueiro", 0, 1 },
                    { 5, "Casemiro", 5, "Volante", 0, 1 },
                    { 6, "Alex Sandro", 6, "Lateral Esquerdo", 0, 1 },
                    { 7, "Lucas Paquetá", 7, "Meio Campo", 0, 1 },
                    { 8, "Bruno Guimarães", 8, "Meio Campo", 0, 2 },
                    { 9, "Richarlison", 10, "Atacante", 0, 1 },
                    { 10, "Vinicius Jr", 11, "Atacante", 0, 1 },
                    { 11, "Rodrygo", 19, "Atacante", 0, 3 },
                    { 12, "Alisson", 23, "Goleiro", 0, 4 }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_JOGADORES");

            migrationBuilder.DropTable(
                name: "TB_JOGOS_SELECOES");

            migrationBuilder.DropTable(
                name: "TB_TECNICOS");

            migrationBuilder.DropTable(
                name: "TB_JOGOS");

            migrationBuilder.DropTable(
                name: "TB_SELECOES");

            migrationBuilder.DropTable(
                name: "TB_ESTADIO");
        }
    }
}
