using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea1.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionConEntradaDettale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entradas",
                columns: table => new
                {
                    EntradaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDeEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradas", x => x.EntradaID);
                });

            migrationBuilder.CreateTable(
                name: "entradasDetalles",
                columns: table => new
                {
                    IdEntradaDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEntrada = table.Column<int>(type: "int", nullable: false),
                    IdLibros = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    EntradaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradasDetalles", x => x.IdEntradaDetalle);
                    table.ForeignKey(
                        name: "FK_entradasDetalles_Libros_IdLibros",
                        column: x => x.IdLibros,
                        principalTable: "Libros",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_entradasDetalles_entradas_EntradaID",
                        column: x => x.EntradaID,
                        principalTable: "entradas",
                        principalColumn: "EntradaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_entradasDetalles_EntradaID",
                table: "entradasDetalles",
                column: "EntradaID");

            migrationBuilder.CreateIndex(
                name: "IX_entradasDetalles_IdLibros",
                table: "entradasDetalles",
                column: "IdLibros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entradasDetalles");

            migrationBuilder.DropTable(
                name: "entradas");
        }
    }
}
