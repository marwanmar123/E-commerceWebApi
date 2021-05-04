using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthJWT.Migrations
{
    public partial class OrderStateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderState_orderStateId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "orderStateId",
                table: "Orders",
                newName: "OrderStateId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_orderStateId",
                table: "Orders",
                newName: "IX_Orders_OrderStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderState_OrderStateId",
                table: "Orders",
                column: "OrderStateId",
                principalTable: "OrderState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderState_OrderStateId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderStateId",
                table: "Orders",
                newName: "orderStateId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderStateId",
                table: "Orders",
                newName: "IX_Orders_orderStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderState_orderStateId",
                table: "Orders",
                column: "orderStateId",
                principalTable: "OrderState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
