using ManagementSystemAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystemAPI.DataAccess.Implementation
{
    public class OrderitemsProvider : IOrderitemsProvider
    {
        public PostgreSqlContext _context;

        public OrderitemsProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddOrderitemsRecord(Orderitems orderitems)
        {
            _context.orderitems.Add(orderitems);
            _context.SaveChanges();
        }

        public void UpdateOrderitemsRecord(Orderitems orderitems)
        {
            _context.orderitems.Update(orderitems);
            _context.SaveChanges();
        }

        public void DeleteOrderitemsRecord(int id)
        {
            var entity = _context.orderitems.FirstOrDefault(t => t.orderitems_id == id);
            _context.orderitems.Remove(entity);
            _context.SaveChanges();
        }

        public Orderitems GetOrderitemsSingleRecord(int id)
        {
            return _context.orderitems.FirstOrDefault(t => t.orderitems_id == id);
        }

        public List<Orderitems> GetOrderItemsByOrderId(int id)
        {
            return _context.orderitems.Where(t => t.orders_id == id).ToList();
        }

        public List<Orderitems> GetOrderitemsRecords()
        {
            return _context.orderitems.ToList();
        }
    }
}
