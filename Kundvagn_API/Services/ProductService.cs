using Kundvagn_API.Context;
using Kundvagn_API.Interfaces;
using Kundvagn_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Kundvagn_API.Services
{
    public class ProductService : IProductService
    {
        private readonly KundvagnContext _context;

        public ProductService(KundvagnContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> PostProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
