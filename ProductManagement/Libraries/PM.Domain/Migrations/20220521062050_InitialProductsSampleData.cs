using Microsoft.EntityFrameworkCore.Migrations;

namespace PM.Domain.Migrations
{
    public partial class InitialProductsSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "CatalogPrice", "CostPrice", "CurrencyId", "FullDescription", "Gtin", "Name", "OldPrice", "Price", "Quantity", "ShortDescription", "Sku" },
                values: new object[] { 1, true, 130m, 100m, 1, null, null, "US Polo Assn Gri Erkek T-Shirt", 140m, 130.62m, 10, "%100 Pamuk / Renk Gri", "1111111" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "CatalogPrice", "CostPrice", "CurrencyId", "FullDescription", "Gtin", "Name", "OldPrice", "Price", "Quantity", "ShortDescription", "Sku" },
                values: new object[] { 2, true, 125m, 105.5m, 1, null, null, "Madmext Erkek Siyah Polo Yaka Tişört", 150m, 123.49m, 15, "Numune Bedeni : L Model Ölçüleri : Boy 1.91 / Kilo 88 Ürünün Kalıbı : Slim Fit Ürün İçeri : %100 Cotton Yıkama Talimatı : 30' Derecede Yıkayınız MADE IN TURKEY", "22222222" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "CatalogPrice", "CostPrice", "CurrencyId", "FullDescription", "Gtin", "Name", "OldPrice", "Price", "Quantity", "ShortDescription", "Sku" },
                values: new object[] { 3, true, 11500m, 10000m, 1, null, null, "Apple iPhone 11 64GB Siyah Cep Telefonu", 12000m, 11991.55m, 100, "(Apple Türkiye Garantili) Aksesuarsız Kutu", "333333333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
