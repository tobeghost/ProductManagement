using Microsoft.EntityFrameworkCore.Migrations;

namespace PM.Domain.Migrations
{
    public partial class InitialCurrenciesSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Active", "CurrencyCode", "Name", "NumberDecimal", "Rate" },
                values: new object[] { 1, true, "TRY", "Türk Lirası", 2, 0m });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Active", "CurrencyCode", "Name", "NumberDecimal", "Rate" },
                values: new object[] { 2, true, "USD", "Amerikan Doları", 2, 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
