using Kundvagn_API.Interfaces;
using Kundvagn_API.Utilities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kundvagn_API.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [NotMapped]
        public List<Cart>? Items  { get; set; }
    }
}
