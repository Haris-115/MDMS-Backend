using ManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.DataAccess
{
    public interface IMedstoresProvider
    {
        void AddMedstoresRecord(Medstores medstores);
        void UpdateMedstoresRecord(Medstores medstores);
        void DeleteMedstoresRecord(int id);
        Medstores GetMedstoresSingleRecord(int id);
        Medstores GetMedstoreByUserId(int id);
        List<Medstores> GetMedstoresRecords();
    }
}
