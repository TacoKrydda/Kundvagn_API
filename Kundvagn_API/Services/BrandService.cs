using Kundvagn_API.Context;
using Kundvagn_API.Interfaces;
using Kundvagn_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Kundvagn_API.Services
{
    public class BrandService : IBrandService
    {
        private readonly KundvagnContext _context;

        public BrandService(KundvagnContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> AddBrand(Brand brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }
    }
}
