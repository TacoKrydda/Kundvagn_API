using Kundvagn_API.Interfaces;
using Kundvagn_API.Models;
using Kundvagn_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kundvagn_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet(Name = "GetOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var result = await _orderService.GetOrders();
            return Ok(result);
        }
        [HttpPost(Name = "PostOrders")]
        public async Task<ActionResult<Brand>> PostBrand(Order order)
        {
            await _orderService.AddOrder(order);
            return Ok(order);
        }
    }
}
