using KometSales.Common.Entities.Dtos;

namespace KometSales.Web.Models
{
    public class SaleItem
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
