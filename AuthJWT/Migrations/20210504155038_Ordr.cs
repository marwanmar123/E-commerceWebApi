using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthJWT.Migrations
{
    public partial class Ordr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderState_OrderStateId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderState",
                table: "OrderState");

            migrationBuilder.RenameTable(
                name: "OrderState",
                newName: "OrderStates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStates",
                table: "OrderStates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStates_OrderStateId",
                table: "Orders",
                column: "OrderStateId",
                principalTable: "OrderStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStates_OrderStateId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStates",
                table: "OrderStates");

            migrationBuilder.RenameTable(
                name: "OrderStates",
                newName: "OrderState");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderState",
                table: "OrderState",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderState_OrderStateId",
                table: "Orders",
                column: "OrderStateId",
                principalTable: "OrderState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
