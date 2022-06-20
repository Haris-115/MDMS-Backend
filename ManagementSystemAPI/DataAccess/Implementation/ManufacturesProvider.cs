using ManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.DataAccess.Implementation
{
    public class ManufacturesProvider : IManufacturesProvider
    {
        public PostgreSqlContext _context;

        public ManufacturesProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddManufacturesRecord(Manufactures manufactures)
        {
            _context.manufactures.Add(manufactures);
            _context.SaveChanges();
        }

        public void UpdateManufacturesRecord(Manufactures manufactures)
        {
            _context.manufactures.Update(manufactures);
            _context.SaveChanges();
        }

        public void DeleteManufacturesRecord(int id)
        {
            var entity = _context.manufactures.FirstOrDefault(t => t.manufactures_id == id);
            _context.manufactures.Remove(entity);
            _context.SaveChanges();
        }

        public Manufactures GetManufacturesSingleRecord(int id)
        {
            return _context.manufactures.FirstOrDefault(t => t.manufactures_id == id);
        }

        public List<Manufactures> GetManufacturesRecords()
        {
            return _context.manufactures.ToList();
        }
    }
}
