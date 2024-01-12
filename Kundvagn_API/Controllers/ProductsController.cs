using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kundvagn_API.Context;
using Kundvagn_API.Models;
using Kundvagn_API.Interfaces;

namespace Kundvagn_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var result = await _productService.GetProducts();
            return Ok(result);
        }
        [HttpPost(Name = "PostProducts")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _productService.PostProduct(product);
            return Ok(product);
        }
    }
}
