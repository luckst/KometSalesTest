using KometSales.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Ifrastructure.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(c => c.UserName)
                .IsRequired(true)
                .HasMaxLength(255);

            builder.Property(c => c.Password)
                .IsRequired(true)
                .HasMaxLength(255);

            builder.Property(c => c.Email)
                .IsRequired(true)
                .HasMaxLength(255);

            builder
                .HasOne(u => u.UserRol)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
