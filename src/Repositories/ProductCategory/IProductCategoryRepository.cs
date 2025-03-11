using ProductService.Domain.Models;

namespace Repositories.ProductCategoryRepository
{
    public interface IProductCategoryRepository
    {
       Task<List<ProductCategoryModel>> GetAllProductCategoriesAsync();
        Task<ProductCategoryModel> GetProductCategoryByIdAsync(int id);
        Task CreateProductCategoryAsync(ProductCategoryModel productCategory);
        Task UpdateProductCategoryAsync(int id, ProductCategoryModel updatedProductCategory);
        Task DeleteProductCategoryAsync(int id); 
    }
}