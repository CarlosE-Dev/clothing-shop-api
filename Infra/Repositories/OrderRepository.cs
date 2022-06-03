using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderDTO>> GetAllDTOAsync()
        {
            return (await _dbset
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.ProductCategory)
                            .AsNoTracking()
                                .ToListAsync())
                                    .Select(x => new OrderDTO()
                                    {
                                        Id = x.Id,
                                        Status = x.Status.ToString(),
                                        Description = x.Description,
                                        CreatedOn = x.CreatedOn,
                                        ModifiedOn = x.ModifiedOn,
                                        OrderItems = x.OrderItems.Select(z => new OrderItemDTO()
                                        {
                                            Id = z.Id,
                                            Quantity = z.Quantity,
                                            ProductId = z.ProductId,
                                            ProductDescription = z.Product.Description,
                                            ProductBrand = z.Product.Brand,
                                            ProductSize = z.Product.Size.ToString(),
                                            ProductValue = z.Product.Value
                                        }),
                                        TotalAmount = x.OrderItems.Sum(y => y.Quantity * y.Product.Value)
                                    });
        }
        public async Task<OrderDTO> GetDTOById(long id)
        {
            return await _dbset
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.ProductCategory)
                            .AsNoTracking()
                                .Select(x => new OrderDTO()
                                {
                                    Id = x.Id,
                                    Status = x.Status.ToString(),
                                    Description = x.Description,
                                    CreatedOn = x.CreatedOn,
                                    ModifiedOn = x.ModifiedOn,
                                    OrderItems = x.OrderItems.Select(z => new OrderItemDTO()
                                    {
                                        Id = z.Id,
                                        Quantity = z.Quantity,
                                        ProductId = z.ProductId,
                                        ProductDescription = z.Product.Description,
                                        ProductBrand = z.Product.Brand,
                                        ProductSize = z.Product.Size.ToString(),
                                        ProductValue = z.Product.Value
                                    }),
                                    TotalAmount = x.OrderItems.Sum(y => y.Quantity * y.Product.Value)
                                })
                                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
