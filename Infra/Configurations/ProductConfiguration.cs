using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Description)
                .HasMaxLength(100)
                    .IsRequired();

            builder.Property(p=>p.Brand)
                .HasMaxLength(100)
                    .IsRequired();

            builder.Property(p => p.Value)
                .HasPrecision(10, 2)
                    .IsRequired();

            builder.Property(p => p.Size)
                .HasConversion<string>()
                    .IsRequired();

            //ef relations
            builder.HasOne(x => x.ProductCategory)
                .WithMany(x => x.Products)
                    .HasForeignKey(k => k.ProductCategoryId)
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
