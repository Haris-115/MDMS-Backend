using ManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.DataAccess
{
    public interface IDistributorsProvider
    {
        void AddDistributorsRecord(Distributors distributors);
        void UpdateDistributorsRecord(Distributors distributors);
        void DeleteDistributorsRecord(int id);
        Distributors GetDistributorsSingleRecord(int id);
        Distributors GetDistributorByUserId(int id);
        List<Distributors> GetDistributorsRecords();
    }
}
