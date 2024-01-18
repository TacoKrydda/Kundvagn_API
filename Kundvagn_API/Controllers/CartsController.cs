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
            var result = _cart.PostCart(request);
            return Ok(result);
        }

        [HttpPut("updateCartQuantity")]
        public IActionResult UpdateCart(CartRequest request) 
        {
            var result = _cart.UpdateCart(request);
            return Ok(result);
        }

        [HttpDelete("removeFromCart")]
        public IActionResult RemoveFromCart(CartRequest request)
        {
            var result = _cart.RemoveCart(request);
            return Ok(result);

        }


        [HttpPost("totalPriceCart")]
        public IActionResult GetCartTotal(CartRequest request)
        {
            var result = _cart.GetCartTotal(request);
            return Ok(result);
        }
    }
}
