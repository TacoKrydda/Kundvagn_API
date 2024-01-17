//using Kundvagn_API.Interfaces;
//using Kundvagn_API.Models;
//using System.Text;
//using System.Text.Json;

//namespace Kundvagn_API.Utilities
//{
//    public class Cart : ICart
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        public List<CartItem> CartItems
//        {
//            get
//            {
//                var session = _httpContextAccessor.HttpContext.Session;
//                if (session.TryGetValue("CartItems", out var cartItems))
//                {
//                    return JsonSerializer.Deserialize<List<CartItem>>(cartItems);
//                }
//                return new List<CartItem>();
//            }
//            set
//            {
//                var session = _httpContextAccessor.HttpContext.Session;
//                session.Set("CartItems", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value)));
//            }
//        }
//        public Cart(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = httpContextAccessor;
//        }

//        public List<CartItem> AddToCart(Product product, int quantity)
//        {
//            Console.WriteLine($"AddToCart called with {product.ProductName} and quantity {quantity}.");
//            CartItem existingItem = CartItems.Find(item => item.Product == product);

//            if (existingItem != null)
//            {
//                existingItem.Quantity += quantity;
//            }
//            else
//            {
//                CartItem newItem = new CartItem(product, quantity);
//                CartItems.Add(newItem);
//            }

//            return CartItems;
//        }

//        public List<CartItem> RemoveFromCart(Product product, int quantity)
//        {
//            CartItem existingItem = CartItems.Find(item => item.Product == product);

//            if (existingItem != null)
//            {
//                if (quantity >= existingItem.Quantity)
//                {
//                    CartItems.Remove(existingItem);
//                }
//                else if (quantity > 0)
//                {
//                    existingItem.Quantity -= quantity;
//                }
//                // If the quantity is less than or equal to 0, do nothing (invalid input).
//            }

//            // Returnera den uppdaterade listan med varukorgsobjekt
//            return CartItems;
//        }


//        public double CalculateTotalPrice()
//        {
//            return CartItems.Sum(item => item.Quantity * item.Product.Price);
//        }
//    }
//}

using Kundvagn_API.Interfaces;
using Kundvagn_API.Models;

namespace Kundvagn_API.Utilities
{
    public class Cart : ICart
    {
        //public List<CartItem> CartItems { get; set; }

        //public Cart()
        //{
        //    CartItems = new List<CartItem>();
        //}

        public List<CartItem> AddToCart(Product product, int quantity, List<CartItem> items)
        {
            CartItem existingItem = items.Find(item => item.Product.ProductId == product.ProductId);

            if (existingItem != null)
            {
                // Skapa en ny lista och kopiera alla element från den befintliga listan
                List<CartItem> updatedCartItems = new List<CartItem>(items);

                // Hitta det aktuella objektet i den kopierade listan
                CartItem updatedItem = updatedCartItems.Find(item => item.Product.ProductId == product.ProductId);

                // Uppdatera antalet i det kopierade objektet
                updatedItem.Quantity += quantity;

                // Tilldela den nya listan till CartItems
                items = updatedCartItems;
            }
            else
            {
                CartItem newItem = new CartItem(product, quantity);
                items.Add(newItem);
            }

            // Returnera den uppdaterade listan med varukorgsobjekt
            return items;
        }

        public List<CartItem> RemoveFromCart(Product product, int quantity, List<CartItem> items)
        {
            CartItem existingItem = items.Find(item => item.Product.ProductId == product.ProductId);

            if (existingItem != null)
            {
                // Skapa en ny lista och kopiera alla element från den befintliga listan
                List<CartItem> updatedCartItems = new List<CartItem>(items);

                if (quantity >= existingItem.Quantity)
                {
                    // Ta bort hela objektet från den kopierade listan om kvantiteten är tillräckligt stor
                    updatedCartItems.Remove(existingItem);
                }
                else if (quantity > 0)
                {
                    // Uppdatera kvantiteten i det kopierade objektet
                    CartItem updatedItem = updatedCartItems.Find(item => item.Product.ProductId == product.ProductId);
                    updatedItem.Quantity -= quantity;
                }
                // If the quantity is less than or equal to 0, do nothing (invalid input).

                // Tilldela den nya listan till CartItems
                items = updatedCartItems;
            }

            // Returnera den uppdaterade listan med varukorgsobjekt
            return items;
        }



        public double CalculateTotalPrice(List<CartItem> items)
        {
            return items.Sum(item => item.Quantity * item.Product.Price);
        }
    }
}