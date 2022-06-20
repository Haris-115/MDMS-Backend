using Microsoft.AspNetCore.Mvc;
using ManagementSystemAPI.DataAccess;
using System;
using System.Collections.Generic;
using ManagementSystemAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    public class MedstoresController : ControllerBase
    {
        private readonly IMedstoresProvider _dataAccessProvider;

        public MedstoresController(IMedstoresProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [EnableCors("MedstoreDetails")]
        [HttpGet]
        public IEnumerable<Medstores> Get()
        {
            return _dataAccessProvider.GetMedstoresRecords();
        }

        [EnableCors("MedstoreDetailsByUserid")]
        [HttpGet("MedstoreDetail/{users_id}")]
        public Medstores DetailsByUserId(int users_id)
        {
            return _dataAccessProvider.GetMedstoreByUserId(users_id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Medstores medstores)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                //medstores.id = obj.ToString();
                _dataAccessProvider.AddMedstoresRecord(medstores);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Medstores Details(int id)
        {
            return _dataAccessProvider.GetMedstoresSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Medstores medstores)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateMedstoresRecord(medstores);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetMedstoresSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteMedstoresRecord(id);
            return Ok();
        }
    }
}
