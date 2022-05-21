using Microsoft.EntityFrameworkCore.Migrations;

namespace PM.Domain.Migrations
{
    public partial class InitialCategoriesSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Active", "Name", "ParentCategoryId" },
                values: new object[] { 1, true, "Giyim", 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Active", "Name", "ParentCategoryId" },
                values: new object[] { 2, true, "Aksesuar", 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Active", "Name", "ParentCategoryId" },
                values: new object[] { 3, true, "Elektronik", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
