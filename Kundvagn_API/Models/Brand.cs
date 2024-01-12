using System.Text.Json.Serialization;

namespace Kundvagn_API.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        [JsonIgnore]
        public List<Product>? Product { get; set; }
    }
}
