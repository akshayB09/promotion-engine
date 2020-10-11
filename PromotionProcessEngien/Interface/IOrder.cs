using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionProcessEngien.Interface
{
    interface IOrder
    {
        List<Order> PlaceOrders(Order[] orders);
        decimal GetFinalPrice(List<Order> orders);
    }
}
