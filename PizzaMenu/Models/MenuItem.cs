namespace PizzaMenu.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageURL { get; set; }
        public decimal Price { get; set; }
        public string? PriceId { get; set; }

        public ICollection<ItemIngredient> ItemIngredients { get; set; }

        public MenuItem()
        {
            ItemIngredients = new List<ItemIngredient>();
        }
    }
}
