using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaMenu.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "House-Made Red Sauce" },
                    { 2, "Mozzarella Cheese" },
                    { 3, "Ground Chuck" },
                    { 4, "Smoked Bacon" },
                    { 5, "Pickles" },
                    { 6, "Cheddar Cheese" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "ImageURL", "Name", "Price" },
                values: new object[] { 1, "https://d2s742iet3d3t1.cloudfront.net/restaurants/restaurant-79069000000000000/menu/items/3/item-500000023251982973_1675199226.png?size=medium", "American Cheeseburger Pizza", 12.99m });

            migrationBuilder.InsertData(
                table: "ItemIngredients",
                columns: new[] { "IngredientId", "MenuItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 6, 1 });

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
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
