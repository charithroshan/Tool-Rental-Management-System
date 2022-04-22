using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolRentalManagement.DataAccess.Migrations
{
    public partial class AddedToolDescriptionInTool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ToolDescription",
                table: "Tools",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToolDescription",
                table: "Tools");
        }
    }
}
