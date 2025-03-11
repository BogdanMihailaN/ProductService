using ProductService.Domain.Models;

namespace Services.ProductCategoryService
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryModel>> GetAllProductCategoriesAsync();
        Task<ProductCategoryModel> GetProductCategoryByIdAsync(int id);
        Task CreateProductCategoryAsync(ProductCategoryModel product);
        Task UpdateProductCategoryAsync(int id, ProductCategoryModel updatedProductCategory);
        Task DeleteProductCategoryAsync(int id);
    }
}