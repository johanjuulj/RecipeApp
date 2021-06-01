using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeApp.Migrations
{
    public partial class newIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

         

            migrationBuilder.DropColumn(
                name: "ShelfLifeDays",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "CaloriesPer100G",
                table: "Ingredients",
                newName: "TotalKgCo2eq");

            migrationBuilder.RenameColumn(
                name: "CO2Per100G",
                table: "Ingredients",
                newName: "Caloriesperkg");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "TotalKgCo2eq",
                table: "Ingredients",
                newName: "CaloriesPer100G");

            migrationBuilder.RenameColumn(
                name: "Caloriesperkg",
                table: "Ingredients",
                newName: "CO2Per100G");

            migrationBuilder.AddColumn<string>(
                name: "Ost",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShelfLifeDays",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CO2Per100G", "CaloriesPer100G", "Name", "Ost", "ShelfLifeDays" },
                values: new object[,]
                {
                    { 1, 20m, 125m, "Minced Meat", null, 7 },
                    { 2, 10m, 85m, "Parmagiano", null, 50 },
                    { 3, 4m, 30m, "Spaghetti", null, 400 },
                    { 4, 10m, 15m, "Tomato", null, 12 }
                });
        }
    }
}
