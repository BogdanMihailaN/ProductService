using Domain.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetProductCategoryById(Guid id)
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
            newProduct.Id = Guid.NewGuid();
            await _productCategoryService.CreateProductCategoryAsync(newProduct);
            return CreatedAtAction(nameof(GetProductCategoryById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductCategory(Guid id, [FromBody] ProductCategoryModel updatedProduct)
        {
            await _productCategoryService.UpdateProductCategoryAsync(id, updatedProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(Guid id)
        {
            await _productCategoryService.DeleteProductCategoryAsync(id);
            return NoContent();
        }
    }
}