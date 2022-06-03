using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class ProductCategoryService : BaseService<ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(IProductCategoryRepository repository) : base(repository)
        {
        }
    }
}
