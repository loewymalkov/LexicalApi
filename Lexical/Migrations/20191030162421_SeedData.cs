using Microsoft.EntityFrameworkCore.Migrations;

namespace Lexical.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Words");

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Words",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Words",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RatingCount",
                table: "Words",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Name", "Rating", "RatingCount" },
                values: new object[,]
                {
                    { 1, "moist", 2.0, 1 },
                    { 2, "damp", 1.0, 1 },
                    { 3, "hug", 4.0, 1 },
                    { 4, "burnt", 5.0, 1 },
                    { 5, "vomit", 1.0, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "WordId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "WordId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "WordId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "WordId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "WordId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "RatingCount",
                table: "Words");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Words",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Words",
                nullable: true);
        }
    }
}
