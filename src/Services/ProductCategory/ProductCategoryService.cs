using ProductService.Domain.Models;
using Repositories.ProductCategoryRepository;

namespace Services.ProductCategoryService
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        
        public async Task CreateProductCategoryAsync(ProductCategoryModel product)
        {
            await _productCategoryRepository.CreateProductCategoryAsync(product);
        }

        public async Task DeleteProductCategoryAsync(int id)
        {
            await _productCategoryRepository.DeleteProductCategoryAsync(id);
        }

        public async Task<List<ProductCategoryModel>> GetAllProductCategoriesAsync()
        {
            return await _productCategoryRepository.GetAllProductCategoriesAsync();
        }

        public async Task<ProductCategoryModel> GetProductCategoryByIdAsync(int id)
        {
            return await _productCategoryRepository.GetProductCategoryByIdAsync(id);
        }

        public async Task UpdateProductCategoryAsync(int id, ProductCategoryModel updatedProductCategory)
        {
            updatedProductCategory.Id = id;
            await _productCategoryRepository.UpdateProductCategoryAsync(updatedProductCategory);
        }
    }
}