using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class ProductDTO
    {
        [Key]
        public long Id { get; set; }
        public long InStock { get; set; }
        public decimal Value { get; set; }

        #region EF Relations

        public long ProductCategoryId { get; set; }
        public ProductCategoryDTO ProductCategory { get; set; }

        #endregion
    }
}
