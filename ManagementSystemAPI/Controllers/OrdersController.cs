using Microsoft.AspNetCore.Mvc;
using ManagementSystemAPI.DataAccess;
using System;
using System.Collections.Generic;
using ManagementSystemAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]

    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider _dataAccessProvider;

        public OrdersController(IOrdersProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [EnableCors("GetMedidOrders")]
        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            return _dataAccessProvider.GetOrdersRecords();
        }

        [EnableCors("PlaceOrder")]
        [HttpPost]
        public IActionResult Create([FromBody] Orders orders)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
               // orders.id = obj.ToString();
                _dataAccessProvider.AddOrdersRecord(orders);
                return Ok(orders.orders_id);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Orders Details(int id)
        {
            return _dataAccessProvider.GetOrdersSingleRecord(id);
        }

        [EnableCors("OrderItemsDetails")]
        [HttpGet("OrderDetails/{distributors_id}")]
        public List<OrderDetails> GetOrderDetails(int distributors_id)
        {
            return _dataAccessProvider.GetOrderDetails(distributors_id);
        }

        [EnableCors("OrderCount")]
        [HttpGet("OrderDetail/{distributors_id}")]
        public int OrderCount(int distributors_id)
        {
            return _dataAccessProvider.GetDistributorOrdersCount(distributors_id);
        }

        [EnableCors("OrderDetails")]
        [HttpGet("OrdersWholeDetails/{distributors_id}")]
        public List<Orders> OrderDetails(int distributors_id)
        {
            return _dataAccessProvider.GetDistributorOrderDetails(distributors_id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateOrdersRecord(orders);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetOrdersSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteOrdersRecord(id);
            return Ok();
        }
    }
}
