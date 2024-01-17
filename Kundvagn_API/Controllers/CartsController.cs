using Kundvagn_API.Interfaces;
using Kundvagn_API.Models;
using Kundvagn_API.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kundvagn_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICart _cart;

        public CartsController(ICart cart)
        {
            _cart = cart;
        }

        [HttpPost("addCart")]
        public IActionResult AddCart(CartRequest request)
        {
            var result = _cart.AddToCart(request.Product, request.Quantity, request.Items);
            return Ok(result);
        }

        [HttpDelete("removeFromCart")]
        public IActionResult RemoveFromCart(CartRequest request)
        {
            var result = _cart.RemoveFromCart(request.Product, request.Quantity, request.Items);
            return Ok(result);

        }


        [HttpGet("totalPriceCart")]
        public IActionResult GetCartTotal(CartRequest request)
        {
            var result = _cart.CalculateTotalPrice(request.Items);
            return Ok(result);
        }
    }
}
