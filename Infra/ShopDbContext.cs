using Domain.Models;
using Domain.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base() { }
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
            
            #region Add Registers

            modelBuilder.Entity<ProductCategory>()
            .HasData(
                new ProductCategory { Id = 1, Description = "100% Cotton", CategoryType = ProductCategoryType.Shirts },
                new ProductCategory { Id = 2, Description = "Belt", CategoryType = ProductCategoryType.Accessories }
            );
            modelBuilder.Entity<Product>()
            .HasData(
                new Product { Id = 1, Description = "T-Shirt", Brand = "Marvel", Value = 19.99m, InStock = 50, Size = ProductSize.S, ProductCategoryId = 1 },
                new Product { Id = 2, Description = "Leather Belt", Brand = "OffWhite", Value = 199.99m, InStock = 5, Size = ProductSize.M, ProductCategoryId = 2 }
            );
            modelBuilder.Entity<Order>()
                .HasData(
                new Order { Id = 1, Description = "Payment Accepted", Status = OrderStatus.Processing},
                new Order { Id = 2, Description = "Sucessful", Status = OrderStatus.Finished }
            );
            modelBuilder.Entity<OrderItem>()
                .HasData(
                new OrderItem { Id = 1, ProductId = 1, Quantity = 2, OrderId = 1 },
                new OrderItem { Id = 2, ProductId = 2, Quantity = 3, OrderId = 2}
            );
            modelBuilder.Entity<User>()
            .HasData(
                new User { Id = 1, Username = "admin", Password = "admin", Role = "admin" },
                new User { Id = 2, Username = "customer", Password = "customer", Role = "customer" }
            );

            #endregion
        }

        #region DbSet

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<OrderItem> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

    }
}
