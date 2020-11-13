using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Library
{
    public partial class Price
    {
        public int ProductId { get; set; }
        public decimal Price1 { get; set; }
        public DateTime StartTime { get; set; }

        public virtual Product Product { get; set; }
    }
}
