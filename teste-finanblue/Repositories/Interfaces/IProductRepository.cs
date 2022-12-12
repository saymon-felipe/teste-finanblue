using teste_finanblue.Models;

namespace teste_finanblue.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> ReturnAllProducts();
        Task<Product> AddProduct(Product product);
    }
}
