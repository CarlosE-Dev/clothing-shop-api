using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class OrderItemDTO
    {
        [Key]
        public long Id { get; set; }
        public long Quantity { get; set; }

        #region Product Propertys

        public string ProductDescription { get; set; }
        public string ProductSize { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductValue { get; set; }
        public long ProductId { get; set; }

        #endregion
    }
}
