using KometSales.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace KometSales.Ifrastructure.EntityConfiguration
{
    public class UserRolConfiguration : IEntityTypeConfiguration<UserRol>
    {
        public void Configure(EntityTypeBuilder<UserRol> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasKey(e => e.Id);

            builder.Property(c => c.RoleName)
                .IsRequired(true)
                .HasMaxLength(50);
        }
    }
}
