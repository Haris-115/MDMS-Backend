using ManagementSystemAPI.Models;
using System.Collections.Generic;

namespace ManagementSystemAPI.DataAccess
{
    public interface IUsersProvider
    {
        int AddUsersRecord(Users users);
        void UpdateUsersRecord(Users users);
        void DeleteUsersRecord(int id);
        Users GetUsersSingleRecord(int id);
        List<Users> GetUsersRecords();
        Users Authenticate(Users users);
        List<Users> GetAll();
    }
}
