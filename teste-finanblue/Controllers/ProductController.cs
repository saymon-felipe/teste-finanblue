using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teste_finanblue.Models;
using teste_finanblue.Repositories.Interfaces;

namespace teste_finanblue.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("/products")]
        public async Task<ActionResult<List<Product>>> ReturnAllProducts()
        {
            List<Product> products = await _productRepository.ReturnAllProducts();
            return Ok(products);
        }

        [HttpPost("/products")]
        [Authorize]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product productModel)
        {
            Product product = await _productRepository.AddProduct(productModel);
            return Ok(product);
        }
    }
}
