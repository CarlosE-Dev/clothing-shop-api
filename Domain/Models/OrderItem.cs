namespace Domain.Models
{
    public class OrderItem : BaseEntity
    {
        public long Quantity { get; set; }

        #region EF Relations

        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }

        #endregion
    }
}