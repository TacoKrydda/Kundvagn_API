using Kundvagn_API.Models;
using Kundvagn_API.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Kundvagn_API.Context
{
    public class KundvagnContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public KundvagnContext(DbContextOptions<KundvagnContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Ange att CartItem inte har någon primärnyckel (kommer inte att representeras som en separat tabell)
        //    modelBuilder.Entity<OrderConfirm>().HasNoKey();
        //}
    }
}
