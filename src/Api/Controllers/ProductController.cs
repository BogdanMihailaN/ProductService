using Microsoft.AspNetCore.Mvc;
using ProductService.Domain.Models;
using Services.Product;

namespace ProductService.Api 
{ 
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductModel newProduct)
        {
            await _productService.CreateProductAsync(newProduct);
            return Ok(newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] ProductModel updatedProduct)
        {
            await _productService.UpdateProductAsync(id, updatedProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
