using Kundvagn_API.Models;
using Kundvagn_API.Utilities;

namespace Kundvagn_API.Interfaces
{
    public interface ICart
    {
        //List<CartItem> CartItems { get; set; }

        List<CartItem> PostCart(CartRequest request);
        List<CartItem> UpdateCart(CartRequest request);
        List<CartItem> RemoveCart(CartRequest request);
        double GetCartTotal(CartRequest request);
    }
}