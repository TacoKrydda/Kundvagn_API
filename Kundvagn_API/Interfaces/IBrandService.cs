using Kundvagn_API.Models;

namespace Kundvagn_API.Interfaces
{
    public interface IBrandService
    {
        Task<Brand> AddBrand(Brand brand);
        Task<IEnumerable<Brand>> GetBrands();
    }
}