using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ShopDbContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _dbset
                        .Include(x => x.Products)
                            .AsNoTracking()
                                .ToListAsync();
        }

        public override async Task<ProductCategory> GetById(long id)
        {
                return await _dbset
                    .Include(x=>x.Products)
                        .AsNoTracking()
                            .SingleOrDefaultAsync(x=>x.Id == id);
        }
    }
}
