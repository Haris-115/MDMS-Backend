using ManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.DataAccess.Implementation
{
    public class MedicinesProvider : IMedicinesProvider
    {
        public PostgreSqlContext _context;

        public MedicinesProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddMedicinesRecord(Medicines medicines)
        {
            _context.medicines.Add(medicines);
            _context.SaveChanges();
        }

        public void UpdateMedicinesRecord(Medicines medicines)
        {
            _context.medicines.Update(medicines);
            _context.SaveChanges();
        }

        public void DeleteMedicinesRecord(int id)
        {
            var entity = _context.medicines.FirstOrDefault(t => t.medicines_id == id);
            _context.medicines.Remove(entity);
            _context.SaveChanges();
        }

        public Medicines GetMedicinesSingleRecord(int id)
        {
            return _context.medicines.FirstOrDefault(t => t.medicines_id == id);
        }

        public List<Medicines> GetMedicinesRecords()
        {
            return _context.medicines.ToList();
        }
    }
}
