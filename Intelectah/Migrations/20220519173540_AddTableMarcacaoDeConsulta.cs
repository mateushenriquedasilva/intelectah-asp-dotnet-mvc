using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intelectah.Migrations
{
    public partial class AddTableMarcacaoDeConsulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcacaoDeConsulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDoPaciente = table.Column<string>(type: "TEXT", nullable: true),
                    IdDoExameCadastrado = table.Column<int>(type: "INTEGER", nullable: false),
                    DataDaConsulta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumeroDeProtocolo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcacaoDeConsulta", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcacaoDeConsulta");
        }
    }
}
