using Microsoft.EntityFrameworkCore;
using PizzaMenu.Models;

namespace PizzaMenu.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ItemIngredient> ItemIngredients { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemIngredient>()
                .HasKey(pi => new
                {
                    pi.MenuItemId,
                    pi.IngredientId
                });
            modelBuilder.Entity<ItemIngredient>()
                .HasOne(pi => pi.Item).WithMany(i => i.ItemIngredients)
                .HasForeignKey(i => i.MenuItemId);
            modelBuilder.Entity<ItemIngredient>()
                .HasOne(pi => pi.Ingredient).WithMany(i => i.ItemIngredients)
                .HasForeignKey(i => i.IngredientId);

            modelBuilder.Entity<MenuItem>()
                .HasData(
                new MenuItem()
                {
                    Id = 1,
                    Name = "American Cheeseburger Pizza",
                    Price = 12.99m,
                    ImageURL = "https://d2s742iet3d3t1.cloudfront.net/restaurants/restaurant-79069000000000000/menu/items/3/item-500000023251982973_1675199226.png?size=medium"
                });

            modelBuilder.Entity<Ingredient>()
                .HasData(
                new Ingredient() { Id = 1, Name = "House-Made Red Sauce"},
                new Ingredient() { Id = 2, Name = "Mozzarella Cheese"},
                new Ingredient() { Id = 3, Name = "Ground Chuck"},
                new Ingredient() { Id = 4, Name = "Smoked Bacon"},
                new Ingredient() { Id = 5, Name = "Pickles"},
                new Ingredient() { Id = 6, Name = "Cheddar Cheese"}
                );

            modelBuilder.Entity<ItemIngredient>()
                .HasData(
                new ItemIngredient() { MenuItemId = 1, IngredientId = 1 },
                new ItemIngredient() { MenuItemId = 1, IngredientId = 2 },
                new ItemIngredient() { MenuItemId = 1, IngredientId = 3 },
                new ItemIngredient() { MenuItemId = 1, IngredientId = 4 },
                new ItemIngredient() { MenuItemId = 1, IngredientId = 5 },
                new ItemIngredient() { MenuItemId = 1, IngredientId = 6 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
