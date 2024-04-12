namespace PizzaMenu.Models
{
    public class ShoppingCartVM
    {
        public List<CartItem> CartItems { get; set; }

        public decimal TotalPrice { get; set; }
        public int TotalAmount { get; set; }
    }
}
