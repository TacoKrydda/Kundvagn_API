using Kundvagn_API.Models;

namespace Kundvagn_API.Utilities
{
    public class CartRequest
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public List<CartItem>? Items { get; set; }
    }
}
