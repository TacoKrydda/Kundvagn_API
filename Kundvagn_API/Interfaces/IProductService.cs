using Kundvagn_API.Models;

namespace Kundvagn_API.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> PostProduct(Product product);
    }
}