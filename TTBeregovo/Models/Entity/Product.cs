namespace TTBeregovo.Models.Entity
{
    public class Product: DbBase
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
    }
}
