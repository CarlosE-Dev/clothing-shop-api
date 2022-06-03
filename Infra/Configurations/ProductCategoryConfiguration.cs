using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("Product Category");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.CategoryType)
                .HasConversion<string>();
        }
    }
}
