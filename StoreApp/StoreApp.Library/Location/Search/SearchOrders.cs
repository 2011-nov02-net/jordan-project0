using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library.Location.Search
{
    class SearchOrders
    {
        public static Order SearchOrdersByFirstName(List<Order> orderHistory, string fName)
        {
            foreach(var order in orderHistory)
            {
                if (fName == order.getFirstName())
                    return order;
            }
            return new Order(0,0);

        }

    }
}
