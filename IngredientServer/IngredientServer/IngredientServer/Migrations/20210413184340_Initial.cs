using Microsoft.EntityFrameworkCore.Migrations;

namespace IngredientServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Ingredient_IngredientId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_IngredientId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "CartItem");

            migrationBuilder.AddColumn<string>(
                name: "ingredientName",
                table: "CartItem",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ingredientPrice",
                table: "CartItem",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ingredientName",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ingredientPrice",
                table: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_IngredientId",
                table: "CartItem",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Ingredient_IngredientId",
                table: "CartItem",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
