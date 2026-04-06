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
            migrationBuilder.CreateTable(
                name: "TB_ESTADIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESTADIO", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_ESTADIO",
                columns: new[] { "Id", "Capacidade", "Cidade", "Nome" },
                values: new object[,]
                {
                    { 1, 2000, "Cidadezona", "Estadio1" },
                    { 2, 1200, "Cidade", "Estadio2" },
                    { 3, 3100, "Osasco", "Estadio3" },
                    { 4, 8000, "Itaquaquecetuba", "Estadio4" },
                    { 5, 1300, "Itapevi", "Estadio5" },
                    { 6, 6700, "Guarulhos", "Estadio6" },
                    { 7, 12000, "São Paulo", "Estadio7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ESTADIO");
        }
    }
}
