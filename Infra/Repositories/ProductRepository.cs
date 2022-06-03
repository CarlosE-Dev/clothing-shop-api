using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopDbContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbset
                        .Include(x => x.ProductCategory)
                            .AsNoTracking()
                                .ToListAsync();
        }
        public override async Task<Product> GetById(long id)
        {
            return await _dbset
                .Include(x => x.ProductCategory)
                    .AsNoTracking()
                        .SingleOrDefaultAsync(i => i.Id == id);
        }
    }
}
