using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ProductService.Domain.Models;
using ProductService.Infrastructure;

namespace Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductServiceDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ProductServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            var productModels = _mapper.Map<List<ProductModel>>(products);
            return productModels;
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            var productModel = _mapper.Map<ProductModel>(product);
            return productModel;
        }

        public async Task CreateProductAsync(ProductModel product)
        {
            var productEntity = _mapper.Map<ProductService.Domain.Entities.Product>(product);
            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int id, ProductModel updatedProduct)
        {
            var productEntity = _mapper.Map<ProductService.Domain.Entities.Product>(updatedProduct);
            productEntity.Id = id;
            _context.Products.Update(productEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var productModel = await GetProductByIdAsync(id);
            var product = _mapper.Map<ProductService.Domain.Entities.Product>(productModel);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}