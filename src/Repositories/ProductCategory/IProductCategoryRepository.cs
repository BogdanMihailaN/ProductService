using Domain.Models;

namespace Repositories.ProductCategoryRepository
{
    public interface IProductCategoryRepository
    {
       Task<List<ProductCategoryModel>> GetAllProductCategoriesAsync();
        Task<ProductCategoryModel> GetProductCategoryByIdAsync(Guid id);
        Task CreateProductCategoryAsync(ProductCategoryModel product);
        Task UpdateProductCategoryAsync(Guid id, ProductCategoryModel updatedProduct);
        Task DeleteProductCategoryAsync(Guid id); 
    }
}