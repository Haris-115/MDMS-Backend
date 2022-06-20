using Microsoft.AspNetCore.Mvc;
using ManagementSystemAPI.DataAccess;
using System;
using System.Collections.Generic;
using ManagementSystemAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]

    public class StocksController : ControllerBase
    {
        private readonly IStocksProvider _dataAccessProvider;

        public StocksController(IStocksProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        [EnableCors("GetStocks")]
        [HttpGet]
        public IEnumerable<Stocks> Get()
        {
            return _dataAccessProvider.GetStocksRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Stocks stocks)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                //distributors.distributors_id = obj.ToString();
                _dataAccessProvider.AddStocksRecord(stocks);
                return Ok();
            }
            return BadRequest();
        }

        [EnableCors("GetStocksDetails")]
        [HttpGet("StockDetails/{medicines_id}")]
        public List<StockDetails> GetStocksWholeDetails(int medicines_id)
        {
            return _dataAccessProvider.GetStocksWholeDetails(medicines_id);
        }

        [HttpGet("{id}")]
        public Stocks Details(int id)
        {
            return _dataAccessProvider.GetStocksSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Stocks stocks)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateStocksRecord(stocks);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetStocksSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteStocksRecord(id);
            return Ok();
        }
    }
}
