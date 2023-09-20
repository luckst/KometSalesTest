namespace KometSales.Domain
{
    public class Product: BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
