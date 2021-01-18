using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WiProTest.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lotes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    data_cadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lotes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "moedas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    moeda = table.Column<string>(type: "varchar(255)", nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_fim = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdLote = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moedas", x => x.id);
                    table.ForeignKey(
                        name: "FK_moedas_lotes_IdLote",
                        column: x => x.IdLote,
                        principalTable: "lotes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_moedas_IdLote",
                table: "moedas",
                column: "IdLote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "moedas");

            migrationBuilder.DropTable(
                name: "lotes");
        }
    }
}
