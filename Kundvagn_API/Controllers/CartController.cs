using Kundvagn_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kundvagn_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cart;

        public CartController(ICart cart)
        {
            _cart = cart;
        }

        [HttpPost("addCart")]
        public IActionResult AddCart(Product product, int Quantity)
        {
            var result = _cart.AddToCart(product, Quantity);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetCartTotal()
        {
            var result = _cart.CalculateTotalPrice();
            return Ok(result);
        }
    }
}
