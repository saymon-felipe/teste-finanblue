using Microsoft.EntityFrameworkCore;
using teste_finanblue.Data;
using teste_finanblue.Models;
using teste_finanblue.Repositories.Interfaces;

namespace teste_finanblue.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly AppDBContext _dbContext;
        public PurchaseRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public async Task<Purchase> AddPurchase(Purchase purchase)
        {
            await _dbContext.Purchases.AddAsync(purchase);
            await _dbContext.SaveChangesAsync();

            return purchase;
        }

        public async Task<List<Purchase>> ReturnAllPurchases()
        {
            return await _dbContext.Purchases.ToListAsync();
        }
    }
}
