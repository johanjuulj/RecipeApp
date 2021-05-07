using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeApp.Migrations
{
    public partial class IngredientList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CO2",
                table: "FoodPlanItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CO2",
                table: "FoodPlanItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
