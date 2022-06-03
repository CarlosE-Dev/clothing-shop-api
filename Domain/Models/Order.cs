using Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Order : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }

        #region EF Relations

        public IEnumerable<OrderItem> OrderItems { get; set; }

        #endregion
    }
}
