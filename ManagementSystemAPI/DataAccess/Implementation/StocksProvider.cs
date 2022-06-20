using System;
using ManagementSystemAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.DataAccess.Implementation
{
    public class StocksProvider : IStocksProvider
    {
        public PostgreSqlContext _context;

        public StocksProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddStocksRecord(Stocks stocks)
        {
            _context.stocks.Add(stocks);
            _context.SaveChanges();
        }

        public void UpdateStocksRecord(Stocks stocks)
        {
            _context.stocks.Update(stocks);
            _context.SaveChanges();
        }

        public void DeleteStocksRecord(int id)
        {
            var entity = _context.stocks.FirstOrDefault(t => t.stocks_id == id);
            _context.stocks.Remove(entity);
            _context.SaveChanges();
        }

        public Stocks GetStocksSingleRecord(int id)
        {
            return _context.stocks.FirstOrDefault(t => t.stocks_id == id);
        }

        public List<Stocks> GetStocksRecords()
        {
            return _context.stocks.ToList();
        }
        public List<StockDetails> GetStocksWholeDetails(int id)
        {
            var stockList = new List<StockDetails>();
            var test = (from meds in _context.medicines
                        join oi in _context.stocks on meds.medicines_id equals oi.medicines_id
                        where oi.medicines_id == id
                        select new StockDetails
                        {
                            medicines_id = meds.medicines_id,
                            medicines_name = meds.medicines_name,
                            price = meds.price,
                            molecule = meds.molecule
                        }).Take(10);
            stockList.AddRange(test.ToList());

            return stockList;

        }
    }
}
