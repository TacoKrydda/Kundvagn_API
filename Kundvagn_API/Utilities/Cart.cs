using Kundvagn_API.Interfaces;
using Kundvagn_API.Models;

namespace Kundvagn_API.Utilities
{
    public class Cart : ICart
    {
        public List<CartItem> PostCart(CartRequest request)
        {
            CartItem existingItem = request.Items.Find(item => item.Product.ProductId ==request.Product.ProductId);

            if (existingItem != null)
            {
                // Uppdatera antalet i objektet
                existingItem.Quantity += request.Quantity;
            }
            else
            {
                CartItem newItem = new CartItem(request.Product, request.Quantity);
                request.Items.Add(newItem);
            }

            // Returnera den uppdaterade listan med varukorgsobjekt
            return request.Items;
        }

        public List<CartItem> UpdateCart(CartRequest request)
        {
            CartItem existingItem = request.Items.Find(item => item.Product.ProductId == request.Product.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity = request.Quantity;
            }

            return request.Items;
        }

        public List<CartItem> RemoveCart(CartRequest request)
        {
            CartItem existingItem = request.Items.Find(item => item.Product.ProductId == request.ProductId);

            if (existingItem != null)
            {
                request.Items.Remove(existingItem);
            }

            return request.Items;
        }

        public double GetCartTotal(CartRequest request)
        {
            var totalPrice = request.Items.Sum(item => item.Quantity * item.Product.Price);
            return totalPrice;
        }
    }
}