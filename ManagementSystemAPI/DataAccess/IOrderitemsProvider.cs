using ManagementSystemAPI.Models;
using System.Collections.Generic;

namespace ManagementSystemAPI.DataAccess
{
    public interface IOrderitemsProvider
    {
        void AddOrderitemsRecord(Orderitems orderitems);
        void UpdateOrderitemsRecord(Orderitems orderitems);
        void DeleteOrderitemsRecord(int id);
        Orderitems GetOrderitemsSingleRecord(int id);
        List<Orderitems> GetOrderItemsByOrderId(int id);
        List<Orderitems> GetOrderitemsRecords();
    }
}
