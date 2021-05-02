using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthJWT.Migrations
{
    public partial class rela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PanierId",
                table: "Paniers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Paniers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paniers_UserId",
                table: "Paniers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paniers_AspNetUsers_UserId",
                table: "Paniers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paniers_AspNetUsers_UserId",
                table: "Paniers");

            migrationBuilder.DropIndex(
                name: "IX_Paniers_UserId",
                table: "Paniers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Paniers");

            migrationBuilder.AddColumn<string>(
                name: "PanierId",
                table: "Paniers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
