namespace PizzaMenu.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ItemIngredient> ItemIngredients { get; set; }

        public Ingredient()
        {
            ItemIngredients = new List<ItemIngredient>();
        }
    }
}
