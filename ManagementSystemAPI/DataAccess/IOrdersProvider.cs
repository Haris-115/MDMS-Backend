using ManagementSystemAPI.Models;
using System.Collections.Generic;

namespace ManagementSystemAPI.DataAccess
{
    public interface IOrdersProvider
    {
        void AddOrdersRecord(Orders orders);
        void UpdateOrdersRecord(Orders orders);
        void DeleteOrdersRecord(int id);
        Orders GetOrdersSingleRecord(int id);
        int GetDistributorOrdersCount(int id);
        List<Orders> GetDistributorOrderDetails(int id);
        List<OrderDetails> GetOrderDetails(int id);
        List<Orders> GetOrdersRecords();
    }
}
