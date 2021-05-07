using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeApp.Migrations
{
    public partial class MovedILAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    RecipeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientLists_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientLists_IngredientId",
                table: "IngredientLists",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientLists");
        }
    }
}
