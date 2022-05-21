using Microsoft.EntityFrameworkCore.Migrations;

namespace PM.Domain.Migrations
{
    public partial class InitialCountriesSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Active", "Name", "TwoLetterIsoCode" },
                values: new object[] { 1, true, "Türkiye", "TR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Active", "Name", "TwoLetterIsoCode" },
                values: new object[] { 2, true, "Denmark", "DK" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Active", "Name", "TwoLetterIsoCode" },
                values: new object[] { 3, true, "Sweden", "SE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
