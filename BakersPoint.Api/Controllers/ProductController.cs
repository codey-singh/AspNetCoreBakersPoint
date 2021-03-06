using BakersPoint.Application;
using BakersPoint.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BakersPoint.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting all Products...");
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Getting product with ID: {ProductId}", id);
            var product = await _productService.GetProductByIdAsync(id);
            
            if (product is not null) return Ok(product);
            
            // If not found
            _logger.LogWarning("Product with ID: {ProductId}, Not found", id);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
            
            return Created($"{@HttpContext.Request.Path}/{product.ProductId}", product);
        }
    }
}