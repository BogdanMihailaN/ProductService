using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ProductService.Domain.Models;
using ProductService.Infrastructure;
using Repositories.ProductCategoryRepository;

namespace Repositories.ProductCategory
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ProductServiceDbContext _context;
        private readonly IMapper _mapper;

        public ProductCategoryRepository(ProductServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductCategoryModel>> GetAllProductCategoriesAsync()
        {
            var productCategories = await _context.ProductCategories.ToListAsync();
            var productCategoriesModels = _mapper.Map<List<ProductCategoryModel>>(productCategories);
            return productCategoriesModels;
        }

        public async Task<ProductCategoryModel> GetProductCategoryByIdAsync(int id)
        {
            var productCategory = await _context.ProductCategories.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            var productCategoryModel = _mapper.Map<ProductCategoryModel>(productCategory);
            return productCategoryModel;
        }

        public async Task CreateProductCategoryAsync(ProductCategoryModel productCategory)
        {
            var productCategoryEntity = _mapper.Map<ProductService.Domain.Entities.ProductCategory>(productCategory);
            await _context.ProductCategories.AddAsync(productCategoryEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductCategoryAsync(int id, ProductCategoryModel updatedProductCategory)
        {
            var productCategoryEntity = _mapper.Map<ProductService.Domain.Entities.ProductCategory>(updatedProductCategory);
            productCategoryEntity.Id = id;
            _context.ProductCategories.Update(productCategoryEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductCategoryAsync(int id)
        {
            var productCategoryModel = await GetProductCategoryByIdAsync(id);
            var productCategory = _mapper.Map<ProductService.Domain.Entities.ProductCategory>(productCategoryModel);
            if (productCategory != null)
            {
                _context.ProductCategories.Remove(productCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}