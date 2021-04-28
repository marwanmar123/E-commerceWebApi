using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthJWT.Migrations
{
    public partial class super : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
