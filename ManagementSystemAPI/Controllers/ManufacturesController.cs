using Microsoft.AspNetCore.Mvc;
using ManagementSystemAPI.DataAccess;
using System;
using System.Collections.Generic;
using ManagementSystemAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]

    public class ManufacturesController : ControllerBase
    {
        private readonly IManufacturesProvider _dataAccessProvider;

        public ManufacturesController(IManufacturesProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [EnableCors("ManufacturesDetails")]
        [HttpGet]
        public IEnumerable<Manufactures> Get()
        {
            return _dataAccessProvider.GetManufacturesRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Manufactures manufactures)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                _dataAccessProvider.AddManufacturesRecord(manufactures);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Manufactures Details(int id)
        {
            return _dataAccessProvider.GetManufacturesSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Manufactures manufactures)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateManufacturesRecord(manufactures);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetManufacturesSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteManufacturesRecord(id);
            return Ok();
        }
    }
}
