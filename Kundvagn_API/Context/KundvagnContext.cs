using Kundvagn_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Kundvagn_API.Context
{
    public class KundvagnContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public KundvagnContext(DbContextOptions<KundvagnContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
    }
}
