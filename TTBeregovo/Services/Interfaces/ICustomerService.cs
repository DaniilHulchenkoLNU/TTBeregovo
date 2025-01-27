namespace TTBeregovo.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<dynamic>> GetBirthdaysAsync(DateTime date);
        Task<IEnumerable<dynamic>> GetRecentBuyersAsync(int days);
        Task<IEnumerable<dynamic>> GetCustomerCategoriesAsync(int customerId);
    }
}
