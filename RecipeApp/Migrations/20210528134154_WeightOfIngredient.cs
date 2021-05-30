using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeApp.Migrations
{
    public partial class WeightOfIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "WeightofIngredient",
                table: "RecipeIngredients",
                nullable: false,
                defaultValue: 0m);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeightofIngredient",
                table: "RecipeIngredients");

            
        }
    }
}
