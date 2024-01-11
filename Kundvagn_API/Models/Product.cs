using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Kundvagn_API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        [JsonIgnore]
        public Brand? Brand { get; set; }
    }
}
