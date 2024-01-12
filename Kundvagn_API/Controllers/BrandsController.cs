using Kundvagn_API.Context;
using Kundvagn_API.Interfaces;
using Kundvagn_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kundvagn_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet(Name = "GetBrands")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            var result = await _brandService.GetBrands();
            return Ok(result);
        }
        [HttpPost(Name = "PostBrands")]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            await _brandService.AddBrand(brand);
            return Ok(brand);
        }
    }
}
