using Kundvagn_API.Models;
using Kundvagn_API.Utilities;

namespace Kundvagn_API.Interfaces
{
    public interface ICart
    {
        List<CartItem> CartItems { get; }

        List<CartItem> AddToCart(Product product, int quantity);
        double CalculateTotalPrice();
        List<CartItem> RemoveFromCart(Product product, int quantity);
    }
}