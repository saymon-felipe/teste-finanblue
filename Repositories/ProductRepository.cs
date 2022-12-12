using Microsoft.EntityFrameworkCore;
using teste_finanblue.Data;
using teste_finanblue.Models;
using teste_finanblue.Repositories.Interfaces;

namespace teste_finanblue.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _dbContext;
        public ProductRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public async Task<Product> AddProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> ReturnAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
