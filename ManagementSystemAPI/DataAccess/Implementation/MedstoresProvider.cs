using ManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.DataAccess.Implementation
{
    public class MedstoresProvider : IMedstoresProvider
    {
        public PostgreSqlContext _context;

        public MedstoresProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddMedstoresRecord(Medstores medstores)
        {
            _context.medstores.Add(medstores);
            _context.SaveChanges();
        }

        public void UpdateMedstoresRecord(Medstores medstores)
        {
            _context.medstores.Update(medstores);
            _context.SaveChanges();
        }

        public void DeleteMedstoresRecord(int id)
        {
            var entity = _context.medstores.FirstOrDefault(t => t.medstores_id == id);
            _context.medstores.Remove(entity);
            _context.SaveChanges();
        }

        public Medstores GetMedstoresSingleRecord(int id)
        {
            return _context.medstores.FirstOrDefault(t => t.medstores_id == id);
        }

        public Medstores GetMedstoreByUserId(int id)
        {
            return _context.medstores.FirstOrDefault(t => t.users_id == id);
        }

        public List<Medstores> GetMedstoresRecords()
        {
            return _context.medstores.ToList();
        }
    }
}
