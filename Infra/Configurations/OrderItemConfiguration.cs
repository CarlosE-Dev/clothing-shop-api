using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("Order Item");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Quantity)
                .HasDefaultValue(1)
                    .IsRequired();

            //ef relations
            builder.HasOne<Order>()
                .WithMany(x => x.OrderItems);

            builder.HasOne(x => x.Product)
                .WithOne(x => x.OrderItem)
                    .HasForeignKey<OrderItem>(x => x.ProductId)
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
