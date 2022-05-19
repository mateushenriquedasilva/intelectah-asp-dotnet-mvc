using Microsoft.EntityFrameworkCore.Migrations;

namespace Intelectah.Migrations
{
    public partial class AddTableTiposdeExame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposDeExames",
                table: "TiposDeExames");

            migrationBuilder.RenameTable(
                name: "TiposDeExames",
                newName: "TiposDeExame");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposDeExame",
                table: "TiposDeExame",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposDeExame",
                table: "TiposDeExame");

            migrationBuilder.RenameTable(
                name: "TiposDeExame",
                newName: "TiposDeExames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposDeExames",
                table: "TiposDeExames",
                column: "id");
        }
    }
}
