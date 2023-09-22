namespace KometSales.Common.Entities.Models
{
    public class SaleModel
    {
        public Guid CustomerId { get; set; }
        public List<SaleDetailModel> SaleDetails { get; set; } = new List<SaleDetailModel>();
    }
}
