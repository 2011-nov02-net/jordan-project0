using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Library
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            ProductOrdereds = new HashSet<ProductOrdered>();
        }

        public int TransactionNumber { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? TransactionTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<ProductOrdered> ProductOrdereds { get; set; }
    }
}
