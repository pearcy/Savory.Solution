using Microsoft.EntityFrameworkCore.Migrations;

namespace Savory.Migrations
{
    public partial class ViewModels1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BakerName",
                table: "Bakers",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Bakers",
                newName: "BakerName");
        }
    }
}
