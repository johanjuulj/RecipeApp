using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeApp.Migrations
{
    public partial class dummeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CO2Per100G", "CaloriesPer100G", "Name", "ShelfLifeDays" },
                values: new object[,]
                {
                    { 1, 20m, 125m, "Minced Meat", 7 },
                    { 2, 10m, 85m, "Parmagiano", 50 },
                    { 3, 4m, 30m, "Spaghetti", 400 },
                    { 4, 10m, 15m, "Tomato", 12 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "ImageUrl", "Kitchen", "Name", "ShortDescription" },
                values: new object[,]
                {
                    { 1, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fopskrifter.coop.dk%2Fopskrifter%2Fspaghetti-bolognese-760&psig=AOvVaw1Idfy2G91X7H3FP8kX0WSg&ust=1620205352346000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCPCa1rbVr_ACFQAAAAAdAAAAABAF", 2, "Bolognese", "Best authentic bolognese recipe in the world" },
                    { 2, "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecake.jpg", 6, "Blueberry Cheese Cake", "You'll love it!" },
                    { 3, "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg", 1, "Steg Flæsk med Persillesovs", "The best of the worst danish cuisine can bring you" },
                    { 4, "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypie.jpg", 6, "Cherry Pie", "A summer classic!" },
                    { 5, "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasapplepie.jpg", 6, "Christmas Apple Pie", "Happy holidays with this pie!" },
                    { 6, "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypie.jpg", 6, "Cranberry Pie", "A Christmas favorite" },
                    { 7, "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpie.jpg", 6, "Peach Pie", "Sweet as peach" },
                    { 8, "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpie.jpg", 6, "Pumpkin Pie", "Our Halloween favorite" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
