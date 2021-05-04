using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthJWT.Migrations
{
    public partial class OrderState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "orderStateId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderState",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderState", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_orderStateId",
                table: "Orders",
                column: "orderStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderState_orderStateId",
                table: "Orders",
                column: "orderStateId",
                principalTable: "OrderState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderState_orderStateId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderState");

            migrationBuilder.DropIndex(
                name: "IX_Orders_orderStateId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "orderStateId",
                table: "Orders");
        }
    }
}
