using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreService.Database.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nname",
                table: "Markets",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Markets",
                newName: "Nname");
        }
    }
}
