using TTBeregovo.DAL.Interfaces;
using TTBeregovo.Models.Entity;

namespace TTBeregovo.Services.Implementations
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IBaseRepository<Purchase> _purchaseRepository;

        public PurchaseService(IBaseRepository<Purchase> purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesAsync()
        {
            return await _purchaseRepository.GetAllAsync();
        }

        public async Task<Purchase> GetPurchaseByIdAsync(int id)
        {
            return await _purchaseRepository.GetByIdAsync(id);
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            await _purchaseRepository.AddAsync(purchase);
            await _purchaseRepository.SaveChangesAsync();
        }

        public async Task UpdatePurchaseAsync(Purchase purchase)
        {
            await _purchaseRepository.UpdateAsync(purchase);
            await _purchaseRepository.SaveChangesAsync();
        }

        public async Task DeletePurchaseAsync(int id)
        {
            await _purchaseRepository.DeleteAsync(id);
            await _purchaseRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByCustomerIdAsync(int customerId)
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            return purchases.Where(p => p.CustomerId == customerId);
        }
    }
}
