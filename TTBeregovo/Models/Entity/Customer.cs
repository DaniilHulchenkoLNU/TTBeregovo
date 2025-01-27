namespace TTBeregovo.Models.Entity
{
    public class Customer: DbBase
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
