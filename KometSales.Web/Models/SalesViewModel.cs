using KometSales.Common.Entities.Dtos;

namespace KometSales.Web.Models
{
    public class SalesViewModel
    {
        public Guid CustomerId { get; set; }
        public List<ProductDto> Products { get; set; }
        public List<SaleItem> CartItems { get; set; } = new List<SaleItem>();
        public decimal TotalPrice => CartItems.Sum(item => item.Price * item.Quantity);
    }
}
