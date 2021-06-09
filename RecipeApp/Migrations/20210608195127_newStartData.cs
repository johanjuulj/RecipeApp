using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeApp.Migrations
{
    public partial class newStartData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://gdurl.com/ECJD");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://gdurl.com/oIcC", "Cabonara" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "http://gdurl.com/4QHf");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Kitchen", "Name" },
                values: new object[] { "https://gdurl.com/r6sb/", 6, "Burrito" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Kitchen", "Name", "ShortDescription" },
                values: new object[] { "https://gdurl.com/ydzp/", 8, "Roll Egg", "Almost as good as a Rolex" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Name", "ShortDescription" },
                values: new object[] { "https://gdurl.com/MCEv", "Hamburger", "As American as they come" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fopskrifter.coop.dk%2Fopskrifter%2Fspaghetti-bolognese-760&psig=AOvVaw1Idfy2G91X7H3FP8kX0WSg&ust=1620205352346000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCPCa1rbVr_ACFQAAAAAdAAAAABAF");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecake.jpg", "Blueberry Cheese Cake" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Kitchen", "Name" },
                values: new object[] { "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypie.jpg", 7, "Cherry Pie" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Kitchen", "Name", "ShortDescription" },
                values: new object[] { "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasapplepie.jpg", 7, "Christmas Apple Pie", "Happy holidays with this pie!" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Name", "ShortDescription" },
                values: new object[] { "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypie.jpg", "Cranberry Pie", "A Christmas favorite" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "ImageUrl", "Kitchen", "Name", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 7, "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpie.jpg", 7, "Peach Pie", 0m, "Sweet as peach" },
                    { 8, "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpie.jpg", 7, "Pumpkin Pie", 0m, "Our Halloween favorite" }
                });
        }
    }
}
