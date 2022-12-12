using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teste_finanblue.Models;
using teste_finanblue.Repositories.Interfaces;

namespace teste_finanblue.Controllers
{
    [ApiController]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICompanyRepository _companyRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository, IProductRepository productRepository, ICompanyRepository companyRepository)
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _companyRepository = companyRepository;
        }

        [HttpGet("/purchases")]
        public async Task<ActionResult<List<Purchase>>> ReturnAllPurchases()
        {
            List<Purchase> purchases = await _purchaseRepository.ReturnAllPurchases();
            return Ok(purchases);
        }

        [HttpPost("/purchases")]
        [Authorize]
        public async Task<ActionResult<Purchase>> AddPurchase(Purchase purchaseModel)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.ElementAt(2).Value);
            List<Product> products = await _productRepository.ReturnAllProducts();
            List<Company> companies = await _companyRepository.ReturnAllCompanies();

            bool validProduct = products.Any(p => p.id == purchaseModel.productId);
            bool validCompany = companies.Any(c => c.id == purchaseModel.companyId);

            if (!validProduct || !validCompany)
            {
                throw new Exception("Produto inválido");
            }

            purchaseModel.clientId = userId;

            Purchase purchase = await _purchaseRepository.AddPurchase(purchaseModel);
            return Ok(purchase);
        }
    }
}
