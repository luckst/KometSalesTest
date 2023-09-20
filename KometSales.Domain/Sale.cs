namespace KometSales.Domain
{
    public class Sale: BaseEntity
    {
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
