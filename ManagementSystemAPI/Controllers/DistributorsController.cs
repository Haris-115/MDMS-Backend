using Microsoft.AspNetCore.Mvc;
using ManagementSystemAPI.DataAccess;
using System;
using System.Collections.Generic;
using ManagementSystemAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]

    public class DistributorsController : ControllerBase
    {
        private readonly IDistributorsProvider _dataAccessProvider;

        public DistributorsController(IDistributorsProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [EnableCors("GetDistributors")]
        [HttpGet]
        public IEnumerable<Distributors> Get()
        {
            return _dataAccessProvider.GetDistributorsRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Distributors distributors)
        {
            if (ModelState.IsValid)
            {
                    Guid obj = Guid.NewGuid();
                //distributors.distributors_id = obj.ToString();
                _dataAccessProvider.AddDistributorsRecord(distributors);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Distributors Details(int id)
        {
            return _dataAccessProvider.GetDistributorsSingleRecord(id);
        }

        [EnableCors("DistributorDetails")]
        [HttpGet("DistributorDetail/{users_id}")]
        public Distributors DetailsByUserId(int users_id)
        {
            return _dataAccessProvider.GetDistributorByUserId(users_id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Distributors distributors)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateDistributorsRecord(distributors);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetDistributorsSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteDistributorsRecord(id);
            return Ok();
        }
    }
}
