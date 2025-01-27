using TTBeregovo.Models.Entity;

namespace TTBeregovo.Services
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> GetAllPurchasesAsync();
        Task<Purchase> GetPurchaseByIdAsync(int id);
        Task AddPurchaseAsync(Purchase purchase);
        Task UpdatePurchaseAsync(Purchase purchase);
        Task DeletePurchaseAsync(int id);
        Task<IEnumerable<Purchase>> GetPurchasesByCustomerIdAsync(int customerId);
    }
}
