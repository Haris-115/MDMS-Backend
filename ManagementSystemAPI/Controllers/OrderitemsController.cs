using Microsoft.AspNetCore.Mvc;
using ManagementSystemAPI.DataAccess;
using System;
using System.Collections.Generic;
using ManagementSystemAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]

    public class OrderitemsController : ControllerBase
    {
        private readonly IOrderitemsProvider _dataAccessProvider;

        public OrderitemsController(IOrderitemsProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Orderitems> Get()
        {
            return _dataAccessProvider.GetOrderitemsRecords();
        }

        [EnableCors("OrderItems")]
        [HttpPost]
        public IActionResult Create([FromBody] Orderitems orderitems)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                //distributors.distributors_id = obj.ToString();
                _dataAccessProvider.AddOrderitemsRecord(orderitems);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Orderitems Details(int id)
        {
            return _dataAccessProvider.GetOrderitemsSingleRecord(id);
        }

        [EnableCors("OrderItemsDetails")]
        [HttpGet("OrderItemsDetail/{orders_id}")]
        public List<Orderitems> DetailsByOrderId(int orders_id)
        {
            return _dataAccessProvider.GetOrderItemsByOrderId(orders_id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Orderitems orderitems)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateOrderitemsRecord(orderitems);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetOrderitemsSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteOrderitemsRecord(id);
            return Ok();
        }
    }
}
