using Kundvagn_API.Models;

namespace Kundvagn_API
{
    public interface ICart
    {
        List<CartItem> CartItems { get; }

        List<CartItem> AddToCart(Product product, int quantity);
        double CalculateTotalPrice();
        List<CartItem> RemoveFromCart(Product product, int quantity);
    }
}