using KometSales.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Ifrastructure.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(e => e.Id);

            builder.Property(c => c.ProductName)
                .IsRequired(true)
                .HasMaxLength(255);

            builder.Property(c => c.Description)
                .IsRequired(false);

            builder.Property(c => c.Price)
                .IsRequired(true)
                .HasPrecision(10, 2);

            builder.Property(c => c.Quantity)
                .IsRequired(true)
                .HasDefaultValue(0);
        }
    }
}
