using System.ComponentModel.DataAnnotations.Schema;

namespace Kundvagn_API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand? Brand { get; set; }
    }
}
