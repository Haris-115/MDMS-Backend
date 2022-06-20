using Microsoft.AspNetCore.Mvc;
using ManagementSystemAPI.DataAccess;
using System;
using System.Collections.Generic;
using ManagementSystemAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]

    public class MedicinesController : ControllerBase
    {
        private readonly IMedicinesProvider _dataAccessProvider;

        public MedicinesController(IMedicinesProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Medicines> Get()
        {
            return _dataAccessProvider.GetMedicinesRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Medicines medicines)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                _dataAccessProvider.AddMedicinesRecord(medicines);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Medicines Details(int id)
        {
            return _dataAccessProvider.GetMedicinesSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Medicines medicines)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateMedicinesRecord(medicines);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetMedicinesSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteMedicinesRecord(id);
            return Ok();
        }
    }
}
