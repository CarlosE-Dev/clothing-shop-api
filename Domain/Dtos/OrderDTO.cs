using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class OrderDTO
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedOn {get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

        #region EF Relations

        public IEnumerable<OrderItemDTO> OrderItems { get; set; }

        #endregion
    }
}
