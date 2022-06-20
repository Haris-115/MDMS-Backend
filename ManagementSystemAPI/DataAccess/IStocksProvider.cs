using ManagementSystemAPI.Models;
using System.Collections.Generic;

namespace ManagementSystemAPI.DataAccess
{
    public interface IStocksProvider
    {
        void AddStocksRecord(Stocks stocks);
        void UpdateStocksRecord(Stocks stocks);
        void DeleteStocksRecord(int id);
        Stocks GetStocksSingleRecord(int id);
        List<StockDetails> GetStocksWholeDetails(int id);
        List<Stocks> GetStocksRecords();
    }
}
