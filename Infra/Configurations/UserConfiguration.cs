using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Username)
                .HasMaxLength(20)
                    .IsRequired();

            builder.Property(p => p.Password)
                .HasMaxLength(50)
                    .IsRequired();

            builder.Property(p => p.Role)
                .HasDefaultValue("customer");

           builder.Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETDATE()")
                    .ValueGeneratedOnAddOrUpdate();
        }
    }
}
