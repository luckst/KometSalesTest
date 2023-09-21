using KometSales.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Ifrastructure.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(e => e.Id);

            builder.Property(c => c.FirstName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(c => c.Email)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(c => c.Address)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(c => c.Phone)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.Property(c => c.Active)
                .IsRequired(true)
                .HasDefaultValue(true);
        }
    }
}
