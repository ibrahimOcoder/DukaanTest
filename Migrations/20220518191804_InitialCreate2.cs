using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsAPI.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStatusDetail_ProductStatus_ProductStatusId1",
                table: "ProductStatusDetail");

            migrationBuilder.DropIndex(
                name: "IX_ProductStatusDetail_ProductStatusId1",
                table: "ProductStatusDetail");

            migrationBuilder.DropColumn(
                name: "ProductStatusId1",
                table: "ProductStatusDetail");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStatusDetail_ProductStatusId",
                table: "ProductStatusDetail",
                column: "ProductStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStatusDetail_ProductStatus_ProductStatusId",
                table: "ProductStatusDetail",
                column: "ProductStatusId",
                principalTable: "ProductStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStatusDetail_ProductStatus_ProductStatusId",
                table: "ProductStatusDetail");

            migrationBuilder.DropIndex(
                name: "IX_ProductStatusDetail_ProductStatusId",
                table: "ProductStatusDetail");

            migrationBuilder.AddColumn<int>(
                name: "ProductStatusId1",
                table: "ProductStatusDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductStatusDetail_ProductStatusId1",
                table: "ProductStatusDetail",
                column: "ProductStatusId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStatusDetail_ProductStatus_ProductStatusId1",
                table: "ProductStatusDetail",
                column: "ProductStatusId1",
                principalTable: "ProductStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
