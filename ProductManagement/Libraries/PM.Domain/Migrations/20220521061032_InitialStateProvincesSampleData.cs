using Microsoft.EntityFrameworkCore.Migrations;

namespace PM.Domain.Migrations
{
    public partial class InitialStateProvincesSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StateProvinces",
                columns: new[] { "Id", "Active", "CountryId", "Name" },
                values: new object[] { 1, true, 1, "Antalya" });

            migrationBuilder.InsertData(
                table: "StateProvinces",
                columns: new[] { "Id", "Active", "CountryId", "Name" },
                values: new object[] { 2, true, 1, "İstanbul" });

            migrationBuilder.InsertData(
                table: "StateProvinces",
                columns: new[] { "Id", "Active", "CountryId", "Name" },
                values: new object[] { 3, true, 1, "İzmir" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StateProvinces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StateProvinces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StateProvinces",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
