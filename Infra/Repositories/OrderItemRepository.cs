using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ShopDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _dbset
                .Include(x => x.Product)
                    .ThenInclude(x=>x.ProductCategory)
                        .AsNoTracking()
                            .ToListAsync();
        }

        public override async Task<OrderItem> GetById(long id)
        {
            return await _dbset
                .Include(x => x.Product)
                    .ThenInclude(x => x.ProductCategory)
                        .AsNoTracking()
                            .SingleOrDefaultAsync(x => x.Id == id);
        }

    }
}
