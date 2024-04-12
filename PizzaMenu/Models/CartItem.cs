namespace PizzaMenu.Models
{
    public class CartItem
    {
        public string? Id { get; set; }
        public MenuItem MenuItem { get; set; }

        public int Amount { get; set; }
    }
}
