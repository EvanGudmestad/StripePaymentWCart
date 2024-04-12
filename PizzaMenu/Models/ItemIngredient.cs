using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMenu.Models
{
    public class ItemIngredient
    {
        public int MenuItemId { get; set; }
        [ForeignKey(nameof(MenuItemId))]
        public MenuItem Item { get; set; } = null!;

        public int IngredientId { get; set; }
        [ForeignKey(nameof(IngredientId))]
        public Ingredient Ingredient { get; set; } = null!;


    }
}
