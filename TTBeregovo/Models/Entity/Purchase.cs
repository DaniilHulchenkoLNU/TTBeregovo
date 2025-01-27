namespace TTBeregovo.Models.Entity
{
    public class Purchase: DbBase
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
