using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.Services.Catalog;
using System.Threading.Tasks;

namespace ProductManagement.API.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
    }
}
