using Kundvagn_API.Models;
using Kundvagn_API.Utilities;

namespace Kundvagn_API.Interfaces
{
    public interface ICart
    {
        List<CartItem> CartItems { get; set; }

        List<CartItem> AddToCart(Product product, int quantity, List<CartItem> items);
        double CalculateTotalPrice();
        List<CartItem> RemoveFromCart(Product product, int quantity);
    }
}