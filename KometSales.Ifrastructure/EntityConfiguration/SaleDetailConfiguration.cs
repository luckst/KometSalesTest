using KometSales.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Ifrastructure.EntityConfiguration
{
    public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("SalesDetail");

            builder.HasKey(e => e.Id);

            builder.Property(c => c.Quantity)
                .IsRequired(true);

            builder.Property(c => c.TotalPrice)
                .IsRequired(true)
                .HasPrecision(10, 2);

            builder
                .HasOne(u => u.Product)
                .WithMany(u => u.SaleDetails)
                .HasForeignKey(u => u.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Sale)
                .WithMany(u => u.SaleDetails)
                .HasForeignKey(u => u.SaleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
