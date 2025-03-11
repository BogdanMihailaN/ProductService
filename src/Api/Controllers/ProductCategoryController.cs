using Microsoft.AspNetCore.Mvc;
using ProductService.Domain.Models;
using Services.ProductCategoryService;

namespace Api.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductCategories()
        {
            var products = await _productCategoryService.GetAllProductCategoriesAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductCategoryById(int id)
        {
            var product = await _productCategoryService.GetProductCategoryByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductCategory([FromBody] ProductCategoryModel newProduct)
        {
            await _productCategoryService.CreateProductCategoryAsync(newProduct);
            return CreatedAtAction(nameof(GetProductCategoryById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductCategory(int id, [FromBody] ProductCategoryModel updatedProduct)
        {
            await _productCategoryService.UpdateProductCategoryAsync(id, updatedProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            await _productCategoryService.DeleteProductCategoryAsync(id);
            return NoContent();
        }
    }
}