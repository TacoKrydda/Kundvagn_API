using Kundvagn_API.Interfaces;
using Kundvagn_API.Models;
using System.Text;
using System.Text.Json;

namespace Kundvagn_API.Utilities
{
    public class Cart : ICart
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public List<CartItem> CartItems
        {
            get
            {
                var session = _httpContextAccessor.HttpContext.Session;
                if (session.TryGetValue("CartItems", out var cartItems))
                {
                    return JsonSerializer.Deserialize<List<CartItem>>(cartItems);
                }
                return new List<CartItem>();
            }
            set
            {
                var session = _httpContextAccessor.HttpContext.Session;
                session.Set("CartItems", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value)));
            }
        }
        public Cart(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<CartItem> AddToCart(Product product, int quantity)
        {
            Console.WriteLine($"AddToCart called with {product.ProductName} and quantity {quantity}.");
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
