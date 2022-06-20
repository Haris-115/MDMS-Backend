using ManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.DataAccess.Implementation
{
    public class OrdersProvider : IOrdersProvider
    {
        public PostgreSqlContext _context;

        public OrdersProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddOrdersRecord(Orders orders)
        {
            _context.orders.Add(orders);
            _context.SaveChanges();
        }

        public void UpdateOrdersRecord(Orders orders)
        {
            _context.orders.Update(orders);
            _context.SaveChanges();
        }

        public void DeleteOrdersRecord(int id)
        {
            var entity = _context.orders.FirstOrDefault(t => t.orders_id == id);
            _context.orders.Remove(entity);
            _context.SaveChanges();
        }

        public Orders GetOrdersSingleRecord(int id)
        {
            return _context.orders.FirstOrDefault(t => t.orders_id == id);
        }
        public int GetDistributorOrdersCount(int id)
        {
            return _context.orders.Count(t => t.distributors_id == id);
        }
        
        public List<Orders> GetDistributorOrderDetails(int id)
        {
            return _context.orders.Where(t => t.distributors_id == id).ToList();
        }
        public List<OrderDetails> GetOrderDetails(int id)
        {
            var orderList = new List<OrderDetails>();
            var test = (from meds in _context.medicines
                        join oi in _context.orderitems on meds.medicines_id equals oi.medicines_id
                        join o in _context.orders on oi.orders_id equals o.orders_id
                        where o.distributors_id == id
                        select new OrderDetails
                        {
                            medicines_name = meds.medicines_name,
                            medicines_price = meds.price,
                            quantity = oi.orderitems_quantity,
                            orders_id = o.orders_id,
                            orderitems_id = oi.orderitems_id
                        }).Take(10);
            orderList.AddRange(test.ToList());
            
            return orderList;
            
        }

        public List<Orders> GetOrdersRecords()
        {
            return _context.orders.ToList();
        }
    }
}
