using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    WeightType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.UniqueConstraint("SK_Barcode", x => x.Barcode);
                    table.ForeignKey(
                        name: "FK_Products_Categories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatusDetail",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductStatusId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductStatusId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatusDetail", x => new { x.ProductId, x.ProductStatusId });
                    table.ForeignKey(
                        name: "FK_ProductStatusDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStatusDetail_ProductStatus_ProductStatusId1",
                        column: x => x.ProductStatusId1,
                        principalTable: "ProductStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Grocery" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 3, "Fridges", 1 },
                    { 4, "LED TVs", 1 },
                    { 5, "Frozen Items", 2 },
                    { 6, "Beverages", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "IN_STOCK" },
                    { 2, "SOLD" },
                    { 3, "DAMAGED" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Description", "Name", "Price", "ProductCategoryId", "Weight", "WeightType" },
                values: new object[,]
                {
                    { 1, "UPC 036725590045", "RZ32M72407F/SG", "RZ32M72407F 1Door with Convertible Mode, Lamb Freeze, 315L", 89000.0, 3, 78.0, 2 },
                    { 2, "UPC 036725596543", "RT29K5030S8/ES", "RT29K5030S8/ES Top Freezer with Twin Cooling Plus™, 299L", 119000.0, 3, 56.0, 2 },
                    { 3, "UPC 036725593647", "QA55Q60AAUXMM", "Q60A QLED 4K Smart TV", 125000.0, 3, 36.0, 2 },
                    { 4, "UPC 036725593019", "UA65AU9000UXMM", "AU9000 Crystal UHD 4K Smart TV", 149000.0, 3, 48.0, 2 },
                    { 5, "UPC 036725931648", "Chicken Nuggets", "Sabroso Nuggets", 745.0, 3, 820.0, 1 },
                    { 6, "UPC 0367259346258", "Chicken Thighs", "Sufi Boneless Thigh", 392.0, 3, 500.0, 1 },
                    { 7, "UPC 0367259956320", "1.5 lt", "Coca Cola", 95.0, 6, 1.5, 3 },
                    { 8, "UPC 0367259564720", "500 mt", "Pepsi", 50.0, 6, 500.0, 4 }
                });

            migrationBuilder.InsertData(
                table: "ProductStatusDetail",
                columns: new[] { "ProductId", "ProductStatusId", "ProductStatusId1", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, null, 10 },
                    { 8, 1, null, 10 },
                    { 7, 2, null, 0 },
                    { 7, 3, null, 0 },
                    { 7, 1, null, 10 },
                    { 6, 2, null, 0 },
                    { 6, 3, null, 0 },
                    { 6, 1, null, 10 },
                    { 5, 2, null, 0 },
                    { 5, 3, null, 0 },
                    { 5, 1, null, 10 },
                    { 4, 2, null, 0 },
                    { 4, 3, null, 0 },
                    { 4, 1, null, 10 },
                    { 3, 2, null, 0 },
                    { 3, 3, null, 0 },
                    { 3, 1, null, 10 },
                    { 2, 2, null, 0 },
                    { 2, 3, null, 0 },
                    { 2, 1, null, 10 },
                    { 1, 2, null, 0 },
                    { 1, 3, null, 0 },
                    { 8, 3, null, 0 },
                    { 8, 2, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStatusDetail_ProductStatusId1",
                table: "ProductStatusDetail",
                column: "ProductStatusId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStatusDetail");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductStatus");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
