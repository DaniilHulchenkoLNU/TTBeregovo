namespace TTBeregovo.Models.Entity
{
    public class PurchaseItem: DbBase
    {
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
