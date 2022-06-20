using ManagementSystemAPI.Models;
using System.Collections.Generic;

namespace ManagementSystemAPI.DataAccess
{
    public interface IManufacturesProvider
    {
        void AddManufacturesRecord(Manufactures manufactures);
        void UpdateManufacturesRecord(Manufactures manufactures);
        void DeleteManufacturesRecord(int id);
        Manufactures GetManufacturesSingleRecord(int id);
        List<Manufactures> GetManufacturesRecords();
    }
}
