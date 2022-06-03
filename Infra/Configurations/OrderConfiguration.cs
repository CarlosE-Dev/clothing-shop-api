using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETDATE()")
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.ModifiedOn)
                .HasDefaultValueSql("GETDATE()")
                    .ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.Status)
                .HasConversion<string>();

            builder.Property(p => p.Description)
                .HasMaxLength(100)
                    .IsRequired();

            //ef relations
            builder.HasMany(x => x.OrderItems)
                .WithOne()
                    .HasForeignKey(k => k.OrderId)
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
