using teste_finanblue.Models;

namespace teste_finanblue.Repositories.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> ReturnAllPurchases();
        Task<Purchase> AddPurchase(Purchase purchases);
    }
}
