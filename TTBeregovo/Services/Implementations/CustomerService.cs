using TTBeregovo.DAL.Interfaces;
using TTBeregovo.Models.Entity;
using TTBeregovo.Services.Interfaces;

namespace TTBeregovo.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IBaseRepository<Customer> _customerRepository;
        private readonly IBaseRepository<Purchase> _purchaseRepository;
        private readonly IBaseRepository<PurchaseItem> _purchaseItemRepository;

        public CustomerService(
            IBaseRepository<Customer> customerRepository,
            IBaseRepository<Purchase> purchaseRepository,
            IBaseRepository<PurchaseItem> purchaseItemRepository)
        {
            _customerRepository = customerRepository;
            _purchaseRepository = purchaseRepository;
            _purchaseItemRepository = purchaseItemRepository;
        }

        public async Task<IEnumerable<dynamic>> GetBirthdaysAsync(DateTime date)
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers
                .Where(c => c.BirthDate.Month == date.Month && c.BirthDate.Day == date.Day)
                .Select(c => new { c.Id, c.FullName });
        }

        public async Task<IEnumerable<dynamic>> GetRecentBuyersAsync(int days)
        {
            var sinceDate = DateTime.Now.AddDays(-days);
            var purchases = await _purchaseRepository.GetAllAsync();

            return purchases
                .Where(p => p.Date >= sinceDate)
                .GroupBy(p => p.Customer)
                .Select(g => new
                {
                    CustomerId = g.Key.Id,
                    FullName = g.Key.FullName,
                    LastPurchaseDate = g.Max(p => p.Date)
                });
        }

        public async Task<IEnumerable<dynamic>> GetCustomerCategoriesAsync(int customerId)
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            var items = purchases
                .Where(p => p.CustomerId == customerId)
                .SelectMany(p => p.PurchaseItems);

            return items
                .GroupBy(i => i.Product.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Quantity = g.Sum(i => i.Quantity)
                });
        }
    }

}
