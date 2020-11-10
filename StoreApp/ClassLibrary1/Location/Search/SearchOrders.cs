using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library.Location.Search
{
    class SearchOrders
    {
        public string SearchOrdersByFirstName(List<Order> orderHistory, string fName)
        {
            string returnedOrder = "";
            foreach(var order in orderHistory)
            {
                if (fName == order.getFirstName())
                    returnedOrder = order.getData();
            }
            return returnedOrder;

        }

    }
}
