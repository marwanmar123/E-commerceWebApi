using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthJWT.Migrations
{
    public partial class supercategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SuperCategoryId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SuperCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SuperCategoryId",
                table: "Categories",
                column: "SuperCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_SuperCategories_SuperCategoryId",
                table: "Categories",
                column: "SuperCategoryId",
                principalTable: "SuperCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_SuperCategories_SuperCategoryId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "SuperCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SuperCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SuperCategoryId",
                table: "Categories");
        }
    }
}
