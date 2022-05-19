using Microsoft.EntityFrameworkCore.Migrations;

namespace Intelectah.Migrations
{
    public partial class AddTableTiposdeExameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "TiposDeExame",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TiposDeExame",
                newName: "id");
        }
    }
}
