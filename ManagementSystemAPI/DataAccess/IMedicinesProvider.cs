using ManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.DataAccess
{
    public interface IMedicinesProvider
    {
        void AddMedicinesRecord(Medicines medicines);
        void UpdateMedicinesRecord(Medicines medicines);
        void DeleteMedicinesRecord(int id);
        Medicines GetMedicinesSingleRecord(int id);
        List<Medicines> GetMedicinesRecords();
    }
}
