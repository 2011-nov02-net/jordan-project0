﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Library
{
    public partial class Inventory
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
