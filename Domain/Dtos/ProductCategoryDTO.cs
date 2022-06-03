using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class ProductCategoryDTO
    {
        [Key]
        public long Id { get; set; }
        public string CategoryType { get; set; }
        public string Description { get; set; }

        #region EF Relations

        public ICollection<ProductDTO> Products { get; set; }

        #endregion
    }
}
