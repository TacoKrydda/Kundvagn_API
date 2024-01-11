using Kundvagn_API.Models;

namespace Kundvagn_API
{
    public class Cart : ICart
    {
        public List<CartItem> CartItems { get; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public List<CartItem> AddToCart(Product product, int quantity)
        {
            CartItem existingItem = CartItems.Find(item => item.Product == product);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                CartItem newItem = new CartItem(product, quantity);
                CartItems.Add(newItem);
            }

            // Returnera den uppdaterade listan med varukorgsobjekt
            return CartItems;
        }

        public List<CartItem> RemoveFromCart(Product product, int quantity)
        {
            CartItem existingItem = CartItems.Find(item => item.Product == product);

            if (existingItem != null)
            {
                if (quantity >= existingItem.Quantity)
                {
                    CartItems.Remove(existingItem);
                }
                else if (quantity > 0)
                {
                    existingItem.Quantity -= quantity;
                }
                // If the quantity is less than or equal to 0, do nothing (invalid input).
            }

            // Returnera den uppdaterade listan med varukorgsobjekt
            return CartItems;
        }


        public double CalculateTotalPrice()
        {
            return CartItems.Sum(item => item.Quantity * item.Product.Price);
        }
    }
}
