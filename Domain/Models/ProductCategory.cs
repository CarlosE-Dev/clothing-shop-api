using Domain.Models.ValueObjects;
using System.Collections.Generic;

namespace Domain.Models
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategoryType CategoryType { get; set; }
        public string Description { get; set; }

        #region EF Relations
        public ICollection<Product> Products { get; set; }

        #endregion
    }
}
