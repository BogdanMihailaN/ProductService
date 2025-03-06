using Domain.Models;

namespace Services.ProductCategoryService
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryModel>> GetAllProductCategoriesAsync();
        Task<ProductCategoryModel> GetProductCategoryByIdAsync(Guid id);
        Task CreateProductCategoryAsync(ProductCategoryModel product);
        Task UpdateProductCategoryAsync(Guid id, ProductCategoryModel updatedProductCategory);
        Task DeleteProductCategoryAsync(Guid id);
    }
}