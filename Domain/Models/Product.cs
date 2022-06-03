using Domain.Models.ValueObjects;

namespace Domain.Models
{
    public class Product : BaseEntity
    {
        public string Description { get; set; }
        public ProductSize Size { get; set; }
        public string Brand { get; set; }
        public decimal Value { get; set; }
        public long InStock { get; set; }

        #region EF Relations
        public long ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public OrderItem OrderItem { get; set; }

        #endregion
    }
}
