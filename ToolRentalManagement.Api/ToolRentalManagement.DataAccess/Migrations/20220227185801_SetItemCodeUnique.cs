using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolRentalManagement.DataAccess.Migrations
{
    public partial class SetItemCodeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemCode",
                table: "Tools",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ItemCode",
                table: "Tools",
                column: "ItemCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tools_ItemCode",
                table: "Tools");

            migrationBuilder.AlterColumn<string>(
                name: "ItemCode",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
