using ManagementSystemAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystemAPI.DataAccess.Implementation
{
    public class DistributorsProvider : IDistributorsProvider
    {
        public PostgreSqlContext _context;

        public DistributorsProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddDistributorsRecord(Distributors distributors)
        {
            _context.distributors.Add(distributors);
            _context.SaveChanges();
        }

        public void UpdateDistributorsRecord(Distributors distributors)
        {
            _context.distributors.Update(distributors);
            _context.SaveChanges();
        }

        public void DeleteDistributorsRecord(int id)
        {
            var entity = _context.distributors.FirstOrDefault(t => t.distributors_id == id);
            _context.distributors.Remove(entity);
            _context.SaveChanges();
        }

        public Distributors GetDistributorsSingleRecord(int id)
        {
            return _context.distributors.FirstOrDefault(t => t.distributors_id == id);
        }
        public Distributors GetDistributorByUserId(int id)
        {
            return _context.distributors.FirstOrDefault(t => t.users_id == id);
        }

        public List<Distributors> GetDistributorsRecords()
        {
            return _context.distributors.ToList();
        }
    }
}
