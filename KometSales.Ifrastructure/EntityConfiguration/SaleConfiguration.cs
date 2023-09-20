using KometSales.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KometSales.Ifrastructure.EntityConfiguration
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(e => e.Id);

            builder.Property(c => c.SaleDate)
                .IsRequired(true);

            builder.Property(c => c.TotalAmount)
                .IsRequired(true)
                .HasPrecision(10, 2);

            builder
                .HasOne(u => u.Customer)
                .WithMany(u => u.Sales)
                .HasForeignKey(u => u.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
